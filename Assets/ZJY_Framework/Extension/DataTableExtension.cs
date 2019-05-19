using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 数据表组件扩展
    /// </summary>
    public static class DataTableExtension
    {
        private const string DataClassPrefixName = "ZJY.Framework.";

        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, object userData = null)
        {
            if (string.IsNullOrEmpty(dataTableName))
            {
                Log.Warning("Data table name is invalid.");
                return;
            }


            string dataClassName = DataClassPrefixName + dataTableName + "DBModel";

            Type dataRowType = Type.GetType(dataClassName);
            if (dataRowType == null)
            {
                Log.Warning("Can not get data type with class name '{0}'.", dataClassName);
                return;
            }

            if (dataTableName.Equals("Localization"))
            {
                dataTableComponent.LoadDataTable(dataRowType, AssetUtility.GetLocalizationDataTableAsset(), Constant.AssetPriority.DataTableAsset, new DataTableInfo(dataTableName, userData));
                return;
            }

            dataTableComponent.LoadDataTable(dataRowType, AssetUtility.GetDataTableAsset(dataTableName), Constant.AssetPriority.DataTableAsset, new DataTableInfo(dataTableName, userData));
        }
    }
}