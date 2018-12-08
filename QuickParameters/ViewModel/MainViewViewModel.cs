// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="CNC Software, Inc.">
//   Copyright (c) 2017 CNC Software, Inc.
// </copyright>
// <summary>
//  If this project is helpful please take a short survey at ->
//  http://ux.mastercam.com/Surveys/APISDKSupport 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuickParameters.ViewModel
{
    using QuickParameters.Commands;

    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Mastercam.Database;

    using GalaSoft.MvvmLight.Messaging;
    using Mastercam.Database.Types;
    using System;

    public class MainViewViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private string operationName;

        private string toolName;

        private int toolNumber;

        private double toolDiameter;

        private double feedrate;

        private int spindleSpeed;

        private string toolPlane;

        #endregion

        #region Construction

        public MainViewViewModel()
        {
            Messenger.Default.Register<Operation>(this, o => ReceiveSelectedOperation(o));

            this.CloseCommand = new DelegateCommand(this.OnCloseCommand);
        }

        #endregion

        #region Commands

        public ICommand CloseCommand { get; }

        #endregion

        #region Public Properties

        public string OperationName
        {
            get => this.operationName;

            set
            {
                this.operationName = value;
                OnPropertyChanged(nameof(this.OperationName));
            }
        }

        public string ToolName
        {
            get => this.toolName;

            set
            {
                this.toolName = value;
                OnPropertyChanged(nameof(this.ToolName));
            }
        }

        public int ToolNumber
        {
            get => toolNumber;

            set
            {
                toolNumber = value;
                OnPropertyChanged(nameof(ToolNumber));
            }
        }

        public double ToolDiameter
        {
            get => toolDiameter;

            set
            {
                toolDiameter = value;
                OnPropertyChanged(nameof(ToolDiameter));
            }
        }

        public double Feedrate
        {
            get => feedrate;

            set
            {
                feedrate = value;
                OnPropertyChanged(nameof(Feedrate));
            }
        }

        public int SpindleSpeed
        {
            get => spindleSpeed;

            set
            {
                spindleSpeed = value;
                OnPropertyChanged(nameof(SpindleSpeed));
            }
        }

        public string ToolPlane
        {
            get => this.toolPlane;

            set
            {
                this.toolPlane = value;
                OnPropertyChanged(nameof(this.ToolPlane));
            }
        }

        #endregion

        #region Private Methods

        private object ReceiveSelectedOperation(Operation operation)
        {
            this.OperationName = $"{GetOperationDescription(operation.Type)}{Environment.NewLine}" +
                                 $"{operation.Name}";
            this.ToolName = operation.OperationTool.Name;
            this.ToolNumber = operation.OperationTool.Number;
            this.ToolDiameter = operation.OperationTool.Diameter;
            this.Feedrate = operation.FeedRate;
            this.SpindleSpeed = operation.SpindleSpeed;
            this.ToolPlane = operation.ToolPlane.ViewName;

            return null;
        }

        private string GetOperationDescription(OperationType operationType)
        {
            switch ((int)operationType)
            {
                case 1:
                    return "Contour";
                    
                case 2:
                    return "Drilling";

                case 3:
                    return "Pocket";

                case 4:
                    return "Transform";

                case 5:
                    return "Rough Parallel";

                case 6:
                    return "Rough Radial";

                case 7:
                    return "Rough Project";

                case 8:
                    return "Rough Flowline";

                case 9:
                    return "Rough Contour";

                case 10:
                    return "Rough Pocket";

                case 11:
                    return "Finish Parallel";

                case 12:
                    return "Finish Radial";

                case 13:
                    return "Finish Project";

                case 14:
                    return "Finish Flowline";

                case 15:
                    return "Finish Contour";

                case 16:
                    return "C-Hook Created";

                case 17:
                    return "Manual Entry";

                case 18:
                    return "Circle mill";

                case 19:
                    return "Point";

                case 20:
                    return "Trimmed";

                case 21:
                    return "Ruled";

                case 22:
                    return "Revolved";

                case 23:
                    return "Letters";

                case 24:
                    return "Swept 2D";

                case 25:
                    return "Swept 3D";

                case 26:
                    return "Coons";

                case 27:
                    return "Lofted";

                case 28:
                    return "Multiaxis Drill";

                case 29:
                case 444:
                    return "Multiaxis Curve";

                case 48:
                case 441:
                    return "Multiaxis SWARF";

                case 442:
                    return "Multiaxis Morph";

                case 100:
                    return "Thread mill";

                case 102:
                    return "Facing";

                case 105:
                    return "Slot Mill";

                case 106:
                    return "Helix Bore";

                case 132:
                    return "Surface High Speed";

                case 134:
                    return "2D High Speed";

                case 443:
                    return "Multiaxis Parallel";

                case 445:
                    return "Multiaxis Triangular Mesh";

                case 446:
                    return "Multiaxis Roughing";

                case 447:
                    return "Multiaxis Project";

                case 448:
                    return "Convert to 5-axis";

                case 449:
                    return "Port Expert";

                case 450:
                    return "Blade Expert";

                case 451:
                    return "Rotary Advanced";

                case 459:
                    return "Deburr";

                default:
                    return "Undefined";
            }
        }

        private void OnCloseCommand(object parameter)
        {
            var view = (Window)parameter;
            view?.Close();
        }
        #endregion

        #region Public Methods

        #endregion

        #region Notify Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}