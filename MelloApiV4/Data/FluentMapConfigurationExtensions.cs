using Dapper.FluentMap;
using Dapper.FluentMap.Configuration;
using Dapper.FluentMap.Mapping;


namespace MelloApiV4.Data
{
    public static class FluentMapConfigurationExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="config"></param>
        /// <param name="mapping"></param>
        public static void AddEntityMapping<T>(this FluentMapConfiguration config, IEntityMap<T> mapping) where T : class, IEntity
        {
            if (!FluentMapper.EntityMaps.ContainsKey(mapping.GetType()))
            {
                config.AddMap(mapping);
            }
        }
    }
}
