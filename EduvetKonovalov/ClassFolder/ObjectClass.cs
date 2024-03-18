using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EduvetKonovalov.ClassFolder
{
    internal class ObjectClass
    {
        public static bool ReferenceEquals(object objA, object objB)
        {
            return objA == objB;
        }

        public static bool Equals(object objA, object objB)
        {
            return objA == objB || (objA != null && objB != null && objA.Equals(objB));
        }

        public virtual bool Equals(object obj)
        {
            return RuntimeHelpers.Equals(this, obj);
        }

    }
}
