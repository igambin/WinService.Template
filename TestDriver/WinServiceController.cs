using System;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using WinService.Implementation;
using WinService.Logging;
using WinService.UnitySetup;

namespace WinService.TestRunner
{
    public partial class WinServiceController : Form
    {
        #region private fields
        public IUnityContainer UnityContainer { get; }
        private readonly ServiceImpl _serviceImpl;

        #endregion

        #region construction

        public WinServiceController()
        {
            InitializeComponent();

            UnityContainer = UnityConfig.Container;

            _serviceImpl = UnityContainer.Resolve<ServiceImpl>();

            ChangeState(ServiceState.Stopped);
        }
         
        #endregion

        #region EventHandler

        private void ButtonStartClick(object sender, EventArgs e)
        {
            this.FileLogger().Debug("Start - Button clicked");
            _serviceImpl.OnStart(null);
            ChangeState(ServiceState.Running);
        }

        private void ButtonPauseClick(object sender, EventArgs e)
        {
            this.FileLogger().Debug("Pause - Button clicked");
            _serviceImpl.OnPause();
            ChangeState(ServiceState.Paused);
        }

        private void ButtonContinueClick(object sender, EventArgs e)
        {
            this.FileLogger().Debug("Continue - Button clicked");
            _serviceImpl.OnContinue();
            ChangeState(ServiceState.Running);
        }

        private void ButtonStopClick(object sender, EventArgs e)
        {
            this.FileLogger().Debug("Stop - Button clicked");
            _serviceImpl.OnStop();
            ChangeState(ServiceState.Stopped);
        }

        private void ButtonShutdownClick(object sender, EventArgs e)
        {
            this.FileLogger().Debug("Shutdown - Button clicked");
            _serviceImpl.OnShutdown();
            ChangeState(ServiceState.Stopped);
        }

        #endregion

        #region private methods

        private void ChangeState(ServiceState newServiceState)
        {
            switch (newServiceState)
            {
                case ServiceState.Stopped:
                    SetButtonstate(true, false, false, false, false);
                    break;
                case ServiceState.Paused:
                    SetButtonstate(false, false, true, false, false);
                    break;
                case ServiceState.Running:
                    SetButtonstate(false, true, false, true, true);
                    break;
            }
        }

        private void SetButtonstate(bool bstart, bool bpause, bool bcontinue, bool bstop, bool bshutdown)
        {
            buttonStart.Enabled = bstart;
            buttonPause.Enabled = bpause;
            buttonContinue.Enabled = bcontinue;
            buttonStop.Enabled = bstop;
            buttonShutdown.Enabled = bshutdown;
        }
        #endregion
    }
}
