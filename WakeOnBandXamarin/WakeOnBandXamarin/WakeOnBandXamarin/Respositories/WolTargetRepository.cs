using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Providers
{
    internal class WolTargetRepository : IWolTargetRepository
    {
        #region Const

        private const string WolTargetsFolder = "data";
        private const string WolTargetsFile = "wol_targets";

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
            // load first
            //var output = JsonConvert.DeserializeObject<ObservableCollection<WolTargetModel>>(jsonCollection);
        }

        async void IWolTargetRepository.SaveWolTargetModels()
        {
            var dataFolder = await GetDataFolder(WolTargetsFolder);
            var file = await dataFolder.CreateFileAsync(WolTargetsFile, CreationCollisionOption.ReplaceExisting);
            var jsonCollection = JsonConvert.SerializeObject(_wolTargets);
            await file.WriteAllTextAsync(jsonCollection);
        }

        private async Task<IFolder> GetDataFolder(string targetFolder)
        {
            var rootFolder = FileSystem.Current.RoamingStorage;
            return await rootFolder.CreateFolderAsync(targetFolder, CreationCollisionOption.OpenIfExists);
        }

        #endregion Methods
    }
}