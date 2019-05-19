namespace ZJY.Framework
{
    public partial class AvtarManager
    {
        private class LoadAvtarInfo
        {
            private readonly AvtarInfo m_AvtarInfo;

            public LoadAvtarInfo(AvtarInfo avtarInfo)
            {
                m_AvtarInfo = avtarInfo;
            }

            public AvtarInfo AvtarInfo
            {
                get
                {
                    return m_AvtarInfo;
                }
            }
        }
    }
}
