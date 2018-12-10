using System;
using System.Numerics;
using NPC.TestCases.T1.Contract;

/// <summary>
/// NPC.TestCases.T1.Contract.Point Custom Methods Implementation
///
/// Processed:       2018-03-19 10:56:31 PM by npcc - NEO Persistable Classes (NPC) Platform 2.1 Compiler v1.0.0.0
/// NPC Project:     https://github.com/mwherman2000/neo-npcc2/blob/master/README.md
/// NPC Lead:        Michael Herman (Toronto) (mwherman@parallelspace.net)
/// </summary>

namespace NPC.TestCases.T1.Contract
{
    public partial class Point    
    {
        public static Point Add(Point e1, Point e2)
        {
            Point e3 = Point.New(e1._x + e2._x, e1._y + e2._y);
            return e3;
        }

        public static Point Subtract(Point e1, Point e2)
        {
            Point e3 = Point.New(e1._x - e2._x, e1._y - e2._y);
            return e3;
        }
    }
}
