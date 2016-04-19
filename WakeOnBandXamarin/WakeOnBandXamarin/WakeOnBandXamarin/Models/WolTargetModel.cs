namespace WakeOnBandXamarin.Core.Models
{
    /// <summary>
    /// Provides a model for Wake on Lan targets
    /// </summary>
    public class WolTargetModel
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="name">Displayed name of the target</param>
        /// <param name="macAddress">Mac address of the target</param>
        public WolTargetModel(string name, string macAddress)
        {
            Name = name;
            MacAddress = macAddress;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Displayed name of the target to wake
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Mac address of the target to wake
        /// </summary>
        public string MacAddress { get; private set; }

        #endregion Properties
    }
}