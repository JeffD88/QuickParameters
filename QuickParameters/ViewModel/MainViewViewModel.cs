namespace QuickParameters.ViewModel
{
    using System;
    using System.Windows.Media;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;

    using Mastercam.Database;
    using Mastercam.Database.Types;
    using Mastercam.Operations.Types;

    using GalaSoft.MvvmLight.Messaging;

    using QuickParameters.Commands;

    public class MainViewViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private SolidColorBrush backgroundBrush;

        private Color backgroundColor;

        private SolidColorBrush headingBrush;

        private Color headingColor;

        private SolidColorBrush labelBrush;

        private Color labelColor;

        private SolidColorBrush parameterBrush;

        private Color parameterColor;

        private string operationName;

        private string toolName;

        private int toolNumber;

        private double toolDiameter;

        private double feedrate;

        private int spindleSpeed;

        private string coolant;

        private string toolPlane;

        private string workOffset;

        #endregion

        #region Construction

        public MainViewViewModel()
        {
            Messenger.Default.Register<Operation>(this, o => ReceiveSelectedOperation(o));

            this.OnLightThemeCommand(null);

            this.LightThemeCommand = new DelegateCommand(this.OnLightThemeCommand);
            this.DarkThemeCommand = new DelegateCommand(this.OnDarkThemeCommand);
            this.SolarizedThemeCommand = new DelegateCommand(this.OnSolarizedThemeCommand);
            this.CloseCommand = new DelegateCommand(this.OnCloseCommand);
        }

        #endregion

        #region Commands

        public ICommand LightThemeCommand { get; }

        public ICommand DarkThemeCommand { get; }

        public ICommand SolarizedThemeCommand { get; }

        public ICommand CloseCommand { get; }

        #endregion

        #region Public Properties

        public SolidColorBrush BackgroundBrush
        {
            get => this.backgroundBrush;

            set
            {
                this.backgroundBrush = value;
                OnPropertyChanged(nameof(this.BackgroundBrush));
            }
        }

        public Color BackgroundColor
        {
            get => this.backgroundColor;

            set
            {
                this.backgroundColor = value;
                this.BackgroundBrush = new SolidColorBrush(this.backgroundColor);
                OnPropertyChanged(nameof(this.BackgroundColor));
            }
        }

        public SolidColorBrush HeadingBrush
        {
            get => this.headingBrush;

            set
            {
                this.headingBrush = value;
                OnPropertyChanged(nameof(this.HeadingBrush));
            }
        }

        public Color HeadingColor
        {
            get => this.headingColor;

            set
            {
                this.headingColor = value;
                this.HeadingBrush = new SolidColorBrush(this.headingColor);
                OnPropertyChanged(nameof(this.HeadingColor));
            }
        }

        public SolidColorBrush LabelBrush
        {
            get => this.labelBrush;

            set
            {
                this.labelBrush = value;
                OnPropertyChanged(nameof(this.LabelBrush));
            }
        }

        public Color LabelColor
        {
            get => this.labelColor;

            set
            {
                this.labelColor = value;
                this.LabelBrush = new SolidColorBrush(this.labelColor);
                OnPropertyChanged(nameof(this.LabelColor));
            }
        }

        public SolidColorBrush ParameterBrush
        {
            get => this.parameterBrush;

            set
            {
                this.parameterBrush = value;
                OnPropertyChanged(nameof(this.ParameterBrush));
            }
        }

        public Color ParameterColor
        {
            get => this.parameterColor;

            set
            {
                this.parameterColor = value;
                this.ParameterBrush = new SolidColorBrush(this.parameterColor);
                OnPropertyChanged(nameof(this.ParameterColor));
            }
        }

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

        public string Coolant
        {
            get => this.coolant;

            set
            {
                this.coolant = value;
                OnPropertyChanged(nameof(this.Coolant));
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

        public string WorkOffset
        {
            get => workOffset;

            set
            {
                workOffset = value;
                OnPropertyChanged(nameof(WorkOffset));
            }
        }

        #endregion

        #region Private Methods

        private object ReceiveSelectedOperation(Operation operation)
        {
            if (operation != null)
            {
                this.OperationName = $"{GetOperationDescription(operation.Type)}{Environment.NewLine}" +
                                     $"{operation.Name}";

                if (operation.OperationTool != null)
                {
                    this.ToolName = operation.OperationTool.Name;
                    this.ToolNumber = operation.OperationTool.Number;
                    this.ToolDiameter = operation.OperationTool.Diameter;
                }

                this.Feedrate = operation.FeedRate;
                this.SpindleSpeed = operation.SpindleSpeed;

                if (operation.Coolant.OperationCoolant == 0)
                {
                    this.Coolant = GetCoolantStatus(operation.Coolant.States);
                }
                else
                {
                    this.Coolant = GetCoolantStatus(operation.Coolant.OperationCoolant);
                }
                
                this.ToolPlane = operation.ToolPlane.ViewName;
                this.WorkOffset = GetWorkOffset(operation.ToolPlane.WorkOffsetNumber);
            }

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

                case 140:
                    return "2D Model Chamfer";

                case 154:
                case 155:
                    return "Linking";

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

        private string GetCoolantStatus(CoolantState states)
        {
            for (int i = 0; i < 10; i++)
            {
                if (states[i] == CoolantStateType.On)
                {
                    return "On";
                }
            }
            return "Off";
        }

        private string GetCoolantStatus(CoolantMode mode)
        {
            switch (mode)
            {
                case CoolantMode.COOL_OFF:
                    return "Off";
                case CoolantMode.COOL_FLOOD:
                    return "Flood";
                case CoolantMode.COOL_MIST:
                    return "Mist";
                case CoolantMode.COOL_TOOL:
                    return "Thru-Tool";
                default:
                    return "Unknown";
            }
        }

        private string GetWorkOffset(short workOffset)
        {
            if (workOffset < 0)
            {
                return "Automatic";
            }
            else
            {
                return workOffset.ToString();
            }
        }

        private void OnLightThemeCommand(object parameter)
        {
            var background = Color.FromRgb(255, 255, 255);
            this.BackgroundBrush = new SolidColorBrush(background);
            this.BackgroundColor = background;

            var heading = Color.FromRgb(0, 0, 0);
            this.HeadingBrush = new SolidColorBrush(heading);
            this.HeadingColor = heading;

            var labels = Color.FromRgb(0, 0, 0);
            this.LabelBrush = new SolidColorBrush(labels);
            this.LabelColor = labels;

            var parameters = Color.FromRgb(0, 0, 0);
            this.ParameterBrush = new SolidColorBrush(parameters);
            this.ParameterColor = parameters;          
        }

        private void OnDarkThemeCommand(object parameter)
        {
            var background = Color.FromRgb(40, 40, 40);
            this.BackgroundBrush = new SolidColorBrush(background);
            this.BackgroundColor = background;

            var heading = Color.FromRgb(104, 157, 106);
            this.HeadingBrush = new SolidColorBrush(heading);
            this.HeadingColor = heading;

            var labels = Color.FromRgb(152, 151, 26);
            this.LabelBrush = new SolidColorBrush(labels);
            this.LabelColor = labels;

            var parameters = Color.FromRgb(146, 131, 116);
            this.ParameterBrush = new SolidColorBrush(parameters);
            this.ParameterColor = parameters;
        }

        private void OnSolarizedThemeCommand(object parameter)
        {
            var background = Color.FromRgb(0, 43, 54);
            this.BackgroundBrush = new SolidColorBrush(background);
            this.BackgroundColor = background;

            var heading = Color.FromRgb(65, 133, 153);
            this.HeadingBrush = new SolidColorBrush(heading);
            this.HeadingColor = heading;

            var labels = Color.FromRgb(38, 139, 210);
            this.LabelBrush = new SolidColorBrush(labels);
            this.LabelColor = labels;

            var parameters = Color.FromRgb(101, 123, 131);
            this.ParameterBrush = new SolidColorBrush(parameters);
            this.ParameterColor = parameters;
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