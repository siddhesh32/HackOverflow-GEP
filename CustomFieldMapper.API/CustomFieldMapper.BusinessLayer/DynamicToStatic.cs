
using System;

namespace SmartFieldMapper.BusinessLayer
{
    public static class DynamicToStatic
    {
        public static T ToStatic<T>(object expando)
        {
            var entity = Activator.CreateInstance<T>();
            return entity;
        }
    }
}
