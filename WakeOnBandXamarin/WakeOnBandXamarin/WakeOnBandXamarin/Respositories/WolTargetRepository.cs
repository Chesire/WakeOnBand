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

        private const string WolTargetsFolder = "app_storage";
        private const string WolTargetsFile = "wol_targets";

        #endregion Const

        #region Fields

        private ObservableCollection<WolTargetModel> _wolTargets;

        #endregion Fields

        #region Constructor

        public WolTargetRepository()
        {
            ((IWolTargetRepository)this).GetWolTargets();
        }

        #endregion Constructor

        #region Methods

        async Task<ObservableCollection<WolTargetModel>> IWolTargetRepository.GetWolTargets()
        {
            return _wolTargets ?? (_wolTargets = await LoadWolTargetModels());
        }

        async void IWolTargetRepository.SaveWolTargetModels()
        {
            var dataFolder = await GetDataFolder(WolTargetsFolder);
            var file = await dataFolder.CreateFileAsync(WolTargetsFile, CreationCollisionOption.ReplaceExisting);
            var jsonCollection = JsonConvert.SerializeObject(_wolTargets);

            await file.WriteAllTextAsync(jsonCollection);
        }

        private async Task<ObservableCollection<WolTargetModel>> LoadWolTargetModels()
        {
            var dataFolder = await GetDataFolder(WolTargetsFolder);
            if ((await dataFolder.CheckExistsAsync(WolTargetsFile)) == ExistenceCheckResult.NotFound)
            {
                return new ObservableCollection<WolTargetModel>();
            }

            IFile file = await dataFolder.GetFileAsync(WolTargetsFile);
            var jsonWolTargets = await file.ReadAllTextAsync();

            if (string.IsNullOrEmpty(jsonWolTargets))
            {
                return new ObservableCollection<WolTargetModel>();
            }

            return JsonConvert.DeserializeObject<ObservableCollection<WolTargetModel>>(jsonWolTargets);
        }

        private async Task<IFolder> GetDataFolder(string targetFolder)
        {
            return await FileSystem.Current.LocalStorage.CreateFolderAsync(targetFolder, CreationCollisionOption.OpenIfExists);
        }

        #endregion Methods
    }
}