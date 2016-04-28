using System;
using System.Collections.ObjectModel;
using MvvmCross.Plugins.File;
using WakeOnBandXamarin.Core.Interfaces;
using WakeOnBandXamarin.Core.Models;

namespace WakeOnBandXamarin.Core.Providers
{
    internal class WolTargetRepository : IWolTargetRepository
    {
        #region Members

        private ObservableCollection<WolTargetModel> _wolTargets;
        private IMvxFileStoreAsync _fileStore;

        #endregion Members

        #region Constructor

        internal WolTargetRepository(IMvxFileStoreAsync fileStore)
        {
            _fileStore = fileStore;
        }

        #endregion Constructor

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
            throw new NotImplementedException();
        }

        #endregion Methods
    }
}