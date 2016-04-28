using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Providers
{
    internal class WolTargetRepository : IWolTargetRepository
    {
        #region Const

        private const string FilePath = "wol_targets";

        #endregion Const

        #region Fields

        private ObservableCollection<WolTargetModel> _wolTargets;

        #endregion Fields

        #region Properties

        ObservableCollection<WolTargetModel> IWolTargetRepository.WolTargets
        {
            get
            {
                if (_wolTargets == null)
                    _wolTargets = new ObservableCollection<WolTargetModel>();

                return _wolTargets;
            }
        }

        #endregion Properties

        #region Methods

        async void IWolTargetRepository.LoadWolTargetModels()
        {
            throw new NotImplementedException();
        }

        async void IWolTargetRepository.SaveWolTargetModels()
        {
            JsonSerializer serial = new JsonSerializer();
            var jsonCollection = JsonConvert.SerializeObject(_wolTargets);

            var output = JsonConvert.DeserializeObject<ObservableCollection<WolTargetModel>>(jsonCollection);

            DataContractSerializer ser = new DataContractSerializer(typeof(ObservableCollection<WolTargetModel>));
        }

        #endregion Methods
    }
}