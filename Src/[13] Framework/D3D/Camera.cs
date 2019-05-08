﻿using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _13__Framework
{
    public class MatrixB
    {
        // Get the world, view, and projection matrices from camera and d3d objects.
        public Matrix viewMatrix { get; set; }
        public Matrix worldMatrix { get; set; }
        public Matrix projectionMatrix { get; set; }
        public Matrix translationMatrix { get; set; }
    }
    public class Camera
    {
        public Vector3 Position { get; set; }

        public Vector3 Right { get; set; }

        public Vector3 Up { get; set; }

        public Vector3 Look { get; set; }

        public float NearZ { get; set; }

        public float FarZ { get; set; }

        public float Aspect { get; set; }

        public float FovY { get; set; }

        public float FovX => 2.0f * (float)Math.Atan(0.5f * NearWindowWidth / NearZ);
            
        
        public float NearWindowWidth { get { return Aspect * NearWindowHeight; } }
        public float NearWindowHeight { get; private set; }
        public float FarWindowWidth { get { return Aspect * FarWindowHeight; } }
        public float FarWindowHeight { get; private set; }

        public Matrix View { get; private set; }
        public Matrix Proj { get; private set; }
        public Matrix ViewProj { get { return View * Proj; } }

        // Constructor
        public Camera()
        {
            Position = new Vector3();
            Right = new Vector3(1, 0, 0);
            Up = new Vector3(0, 1, 0);
            Look = new Vector3(0, 0, 1);

            View = Matrix.Identity;
            Proj = Matrix.Identity;

            SetLens(0.25f * (float)Math.PI, 1.0f, 1.0f, 1000.0f);
        }

        // Methods.
        public void SetLens(float fovY, float aspect, float zn, float zf)
        {
            FovY = fovY;
            Aspect = aspect;
            NearZ = zn;
            FarZ = zf;

            NearWindowHeight = 2.0f * NearZ * (float)Math.Tan(0.5f * FovY);
            FarWindowHeight = 2.0f * FarZ * (float)Math.Tan(0.5f * FovY);

            Proj = Matrix.PerspectiveFovLH(FovY, Aspect, NearZ, FarZ);
        }

        public void Strafe(float d)
        {
            Position += Right * d;
        }

        public void Walk(float d)
        {
            Position += Look * d;
        }

        public void Pitch(float angle)
        {
            Matrix r = Matrix.RotationAxis(Right, angle);
            Up = Vector3.TransformNormal(Up, r);
            Look = Vector3.TransformNormal(Look, r);
        }

        public void Yaw(float angle)
        {
            Matrix r = Matrix.RotationY(angle);
            Right = Vector3.TransformNormal(Right, r);
            Up = Vector3.TransformNormal(Up, r);
            Look = Vector3.TransformNormal(Look, r);
        }

        public void UpdateViewMatrix()
        {
            Vector3 r = Right;
            Vector3 u = Up;
            Vector3 l = Look;
            Vector3 p = Position;

            l = Vector3.Normalize(l);
            u = Vector3.Normalize(Vector3.Cross(l, r));

            r = Vector3.Cross(u, l);

            Single x = -Vector3.Dot(p, r);
            Single y = -Vector3.Dot(p, u);
            Single z = -Vector3.Dot(p, l);

            Right = r;
            Up = u;
            Look = l;

            Matrix v = new Matrix();
            v[0, 0] = Right.X;
            v[1, 0] = Right.Y;
            v[2, 0] = Right.Z;
            v[3, 0] = x;

            v[0, 1] = Up.X;
            v[1, 1] = Up.Y;
            v[2, 1] = Up.Z;
            v[3, 1] = y;

            v[0, 2] = Look.X;
            v[1, 2] = Look.Y;
            v[2, 2] = Look.Z;
            v[3, 2] = z;

            v[0, 3] = v[1, 3] = v[2, 3] = 0;
            v[3, 3] = 1;

            View = v;
        }


    }
}
