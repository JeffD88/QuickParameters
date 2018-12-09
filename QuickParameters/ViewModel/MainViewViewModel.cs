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
    using QuickParameters.Resources;

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

        private string operationHeading;

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

            Initialize();
         
            this.LightThemeCommand = new DelegateCommand(this.OnLightThemeCommand);
            this.DarkThemeCommand = new DelegateCommand(this.OnDarkThemeCommand);
            this.SolarizedThemeCommand = new DelegateCommand(this.OnSolarizedThemeCommand);
        }

        private void Initialize()
        {
            this.ToolNameLabel = Strings.ToolNameLabel;
            this.ToolNumberLabel = Strings.ToolNumberLabel;
            this.ToolDiameterLabel = Strings.ToolDiameterLabel;
            this.FeedRateLabel = Strings.FeedRateLabel;
            this.SpindleSpeedLabel = Strings.SpindleSpeedLabel;
            this.CoolantLabel = Strings.CoolantLabel;
            this.ToolPlaneLabel = Strings.ToolPlaneLabel;
            this.WorkOffsetLabel = Strings.WorkOffsetLabel;

            this.ContextMenuColors = Strings.ContextMenuColors;
            this.ContextMenuThemes = Strings.ContextMenuThemes;
            this.ContextMenuLight = Strings.ContextMenuLight;
            this.ContextMenuDark = Strings.ContextMenuDark;
            this.ContextMenuSolarized = Strings.ContextMenuSolarized;
            this.ContextMenuCustom = Strings.ContextMenuCustom;
            this.ContextMenuBackground = Strings.ContextMenuBackground;
            this.ContextMenuBackgroundHeader = Strings.ContextMenuBackgroundHeader;
            this.ContextMenuHeading = Strings.ContextMenuHeading;
            this.ContextMenuHeadingHeader = Strings.ContextMenuHeadingHeader;
            this.ContextMenuLabel = Strings.ContextMenuLabel;
            this.ContextMenuLabelHeader = Strings.ToolNameLabel;
            this.ContextMenuParameters = Strings.ContextMenuParameters;
            this.ContextMenuParametersHeader = Strings.ContextMenuParametersHeader;

            this.OnLightThemeCommand(null);
        }

        #endregion

        #region Commands

        public ICommand LightThemeCommand { get; }

        public ICommand DarkThemeCommand { get; }

        public ICommand SolarizedThemeCommand { get; }

        #endregion

        #region Public Properties

        public string ContextMenuColors { get; set; }

        public string ContextMenuThemes { get; set; }

        public string ContextMenuLight { get; set; }

        public string ContextMenuDark { get; set; }

        public string ContextMenuSolarized { get; set; }

        public string ContextMenuCustom { get; set; }

        public string ContextMenuBackground { get; set; }

        public string ContextMenuBackgroundHeader { get; set; }

        public string ContextMenuHeading { get; set; }

        public string ContextMenuHeadingHeader { get; set; }

        public string ContextMenuLabel { get; set; }

        public string ContextMenuLabelHeader { get; set; }

        public string ContextMenuParameters { get; set; }

        public string ContextMenuParametersHeader { get; set; }

        public string ToolNameLabel { get; set; }

        public string ToolNumberLabel { get; set; }

        public string ToolDiameterLabel { get; set; }

        public string FeedRateLabel { get; set; }

        public string SpindleSpeedLabel { get; set; }

        public string CoolantLabel { get; set; }

        public string ToolPlaneLabel { get; set; }

        public string WorkOffsetLabel { get; set; }

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

        public string OperationHeading
        {
            get => this.operationHeading;

            set
            {
                this.operationHeading = value;
                OnPropertyChanged(nameof(this.OperationHeading));
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
                this.OperationHeading = $"{GetOperationDescription(operation.Type)}{Environment.NewLine}" +
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
                    return Strings.Contour;

                case 2:
                    return Strings.Drill;

                case 3:
                    return Strings.Pocket;

                case 4:
                    return Strings.Transform;

                case 5:
                    return Strings.SurfaceRoughParallel;

                case 6:
                    return Strings.SurfaceRoughRadial;

                case 7:
                    return Strings.SurfaceRoughProject;

                case 8:
                    return Strings.SurfaceRoughFlowline;

                case 9:
                    return Strings.SurfaceRoughContour;

                case 10:
                    return Strings.SurfaceRoughPocket;

                case 11:
                    return Strings.SurfaceFinishParallel;

                case 12:
                    return Strings.SurfaceFinishRadial;

                case 13:
                    return Strings.SurfaceFinishProject;

                case 14:
                    return Strings.SurfaceFinishFlowline;

                case 15:
                    return Strings.SurfaceFinishContour;

                case 17:
                    return Strings.ManualEntry;

                case 18:
                    return Strings.CircleMill;

                case 19:
                    return Strings.Point;

                case 20:
                    return Strings.Trimmed;

                case 21:
                    return Strings.Ruled;

                case 22:
                    return Strings.Revolved;

                case 23:
                    return Strings.Letters;

                case 24:
                    return Strings.Swept2D;

                case 25:
                    return Strings.Swept3D;

                case 26:
                    return Strings.Coons;

                case 27:
                    return Strings.Lofted;

                case 28:
                    return Strings.MultiaxisDrill;

                case 29:
                case 444:
                    return Strings.MultiaxisCurve;

                case 44:
                    return Strings.SurfaceRoughPlunge;

                case 48:
                case 441:
                    return Strings.MultiaxisSWARF;

                case 442:
                    return Strings.MultiaxisMorph;

                case 100:
                    return Strings.ThreadMill;

                case 102:
                    return Strings.Facing;

                case 105:
                    return Strings.SlotMilling;

                case 106:
                    return Strings.HelixBore;

                case 111:
                    return Strings.Slice5Axis;

                case 112:
                    return Strings.Port5Axis;

                case 113:
                    return Strings.FiveAxisCircle;

                case 130:
                    return Strings.TabCutoff;

                case 131:
                    return Strings.MultisurfaceRoughPocket;

                case 132:
                    return Strings.SurfaceHighSpeed;

                case 133:
                    return Strings.OnionskinNesting;

                case 134:
                    return Strings.TwoDHighSpeed;

                case 135:
                    return Strings.Saw;

                case 136:
                    return Strings.FBMDrillControlOperation;

                case 137:
                    return Strings.FBMMillPocketOperation;

                case 138:
                    return Strings.FBMMillContourOperation;

                case 139:
                    return Strings.SolidModelOperation;

                case 140:
                    return Strings.ModelChamfer;

                case 150:
                    return Strings.ProbeCycleProbeMotion;

                case 151:
                    return Strings.ProbeCycleCommandBlock;

                case 152:
                    return Strings.ProbeCycleHeader;

                case 153:
                    return Strings.ProbeCycleTrailer;
;
                case 154:
                case 155:
                    return Strings.MultiaxisLink;

                case 416:
                    return Strings.Engraving;

                case 439:
                    return Strings.Art;

                case 443:
                    return Strings.MultiaxisParallel;

                case 445:
                    return Strings.MultiaxisTriangularMesh;

                case 446:
                    return Strings.MultiaxisRoughing;

                case 447:
                    return Strings.MultiaxisProject;

                case 448:
                    return Strings.ConvertTo5Axis;

                case 449:
                    return Strings.PortExpert;

                case 450:
                    return Strings.BladeExpert;

                case 451:
                    return Strings.RotaryAdvanced;

                case 459:
                    return Strings.Deburr;

                default:
                    return Strings.Unknown;
            }
        }

        private string GetCoolantStatus(CoolantState states)
        {
            for (int i = 0; i < 10; i++)
            {
                if (states[i] == CoolantStateType.On)
                {
                    return Strings.CoolantOn;
                }
            }
            return Strings.CoolantOff;
        }

        private string GetCoolantStatus(CoolantMode mode)
        {
            switch (mode)
            {
                case CoolantMode.COOL_OFF:
                    return Strings.CoolantOff;

                case CoolantMode.COOL_FLOOD:
                    return Strings.CoolantFlood;

                case CoolantMode.COOL_MIST:
                    return Strings.CoolantMist;

                case CoolantMode.COOL_TOOL:
                    return Strings.CoolantThruTool;

                default:
                    return Strings.Unknown;
            }
        }

        private string GetWorkOffset(short workOffset)
        {
            if (workOffset < 0)
            {
                return Strings.AutomaticWorkOffset;
            }
            else
            {
                return workOffset.ToString();
            }
        }

        private void OnLightThemeCommand(object parameter)
        {
            var background = Color.FromRgb(255, 255, 255);
            var heading = Color.FromRgb(0, 0, 0);
            var labels = Color.FromRgb(0, 0, 0);
            var parameters = Color.FromRgb(0, 0, 0);

            SetTheme(background, heading, labels, parameters);
        }

        private void OnDarkThemeCommand(object parameter)
        {
            var background = Color.FromRgb(40, 40, 40);
            var heading = Color.FromRgb(104, 157, 106);
            var labels = Color.FromRgb(152, 151, 26);
            var parameters = Color.FromRgb(146, 131, 116);

            SetTheme(background, heading, labels, parameters);
        }

        private void OnSolarizedThemeCommand(object parameter)
        {
            var background = Color.FromRgb(0, 43, 54);
            var heading = Color.FromRgb(65, 133, 153);
            var labels = Color.FromRgb(38, 139, 210);
            var parameters = Color.FromRgb(101, 123, 131);

            SetTheme(background, heading, labels, parameters);
        }

        private void SetTheme(Color background, Color heading, Color labels, Color parameters)
        {
            this.BackgroundBrush = new SolidColorBrush(background);
            this.BackgroundColor = background;

            this.HeadingBrush = new SolidColorBrush(heading);
            this.HeadingColor = heading;

            this.LabelBrush = new SolidColorBrush(labels);
            this.LabelColor = labels;

            this.ParameterBrush = new SolidColorBrush(parameters);
            this.ParameterColor = parameters;
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