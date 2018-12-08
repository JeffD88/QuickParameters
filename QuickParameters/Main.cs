namespace QuickParameters
{
    using GalaSoft.MvvmLight.Messaging;
    using Mastercam.App;
    using Mastercam.App.Types;
    using Mastercam.Support;
    using System.Linq;
    using QuickParameters.Views;

    public class Main : NetHook3App
    {

        #region Public Override Methods

        public override MCamReturn Run(int param)
        {
            var view = new MainView();
            view.Show();

            return MCamReturn.NoErrors;
        }

        public override MCamReturn Notify(MCamEvent eventFlag)
        {
            switch (eventFlag)
            {
                case MCamEvent.OperationSelectionsChanged:
                    var selectedOperations = SearchManager.GetOperations(true);
                    if (selectedOperations.Any())
                    {
                        Messenger.Default.Send(selectedOperations[0]);                                    
                    }
                    return MCamReturn.NoErrors;

                default:
                    return MCamReturn.NoErrors;
            }
        }

        #endregion
    }
}
