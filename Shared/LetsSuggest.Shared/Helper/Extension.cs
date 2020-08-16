using System.Linq;
using System.Reflection;

namespace LetsSuggest.Shared.Helper
{
    public static class Extension
    {
        public static object CopyTo(this object Base, object New)
        {
            if (Base == null)
            {
                return New;
            }


            foreach (PropertyInfo oldProp in Base.GetType().GetProperties())
            {
                if (New.GetType().GetProperties().Count(t => t.Name == oldProp.Name) > 0)
                {
                    PropertyInfo newProp = New.GetType().GetProperty(oldProp.Name);
                    if (newProp != null)
                    {
                        object propValue = oldProp.GetValue(Base, null);
                        newProp.SetValue(New, propValue, null);
                    }
                }
            }

            foreach (FieldInfo oldField in Base.GetType().GetFields())
            {
                if (New.GetType().GetFields().Count(t => t.Name == oldField.Name) > 0)
                {
                    FieldInfo newField = New.GetType().GetField(oldField.Name);
                    if (newField != null)
                    {
                        object fieldValue = oldField.GetValue(Base);
                        newField.SetValue(New, fieldValue);
                    }
                }
            }
            return New;
        }
    }
}
