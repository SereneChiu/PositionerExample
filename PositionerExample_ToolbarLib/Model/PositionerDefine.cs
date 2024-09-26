using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;

namespace PositionerExample_ToolbarLib.Model
{
    public static class PositionerDefine
    {
        public enum State : ushort
        {
            [Description("Normal")]
            NORMAL,
            [Description("Warning")]
            WARNING,
            [Description("Error")]
            ERROR,
        }

    }

    public static class EnumExtensions
    {
        public static string ToDisplayName(this Enum value)
        {
            Type type = value.GetType();

            MemberInfo[] memInfo = type.GetMember(value.ToString());

            // no attributes found ?
            if (memInfo.Length == 0) return string.Empty;

            // cast to Array or List required 
            // an IEnumerable of DescriptionAttribute cannot be indexed !
            DescriptionAttribute[] attributes = memInfo[0].GetCustomAttributes<DescriptionAttribute>(false).ToArray();

            // handle value without description
            return (attributes.Length == 0) ? string.Empty : attributes[0].Description;
        }

    }

}
