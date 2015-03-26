namespace DevDumps.WPFSDK.UI.Key
{
    /// <summary>
    /// ResourceKey to access DevDumps Brand Brushes.
    /// 
    /// The source of this information is: 
    /// http://groupspaces.intranet.DevDumps.co.uk/sites/DevDumpsgroup/Brand%20Guidelines%202012/Brand%20tertiary%20colour%20palette%20v1.0%20Feb%202012.pdf
    /// http://groupspaces.intranet.DevDumps.co.uk/sites/DevDumpsgroup/Brand%20Guidelines%202012/Brand%20guidelines%20v1.0%20Mar%202012.pdf
    /// 
    /// Note: These resources should probably not be change.
    /// </summary>
    public class DevDumpsBrushKey : EnumIdResourceKeyBase<DevDumpsColourIdEnum>
    {
        /// <summary>
        /// Constructor for usage in markup extension.
        /// </summary>
        /// <param name="id"></param>
        public DevDumpsBrushKey(DevDumpsColourIdEnum id)
            : base(id)
        {
        }

        /// <summary>
        /// Constructor for usage in markup extension with named parameter.
        /// </summary>
        public DevDumpsBrushKey()
        {
        }
    }
}