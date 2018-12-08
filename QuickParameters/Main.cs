// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Main.cs" company="CNC Software, Inc.">
//   Copyright (c) 2017 CNC Software, Inc.
// </copyright>
// <summary>
//  If this project is helpful please take a short survey at ->
//  http://ux.mastercam.com/Surveys/APISDKSupport 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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

        /// <summary>
        /// The main entry point for your NETHook.
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of your NetHook application.</returns>
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
