namespace QuickParameters.ViewModel
{
    using System;
    using System.Windows.Media;
    using System.Windows.Input;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

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

        private SolidColorBrush headingBrush;

        private SolidColorBrush labelBrush;

        private SolidColorBrush parameterBrush;

        private string toolPlaneLabel;

        private string operationHeading;

        private string toolName;

        private string toolNumber;

        private string toolDiameter;

        private string toolLengthOffset;

        private string toolDiameterOffset;

        private string feedrate;

        private string spindleSpeed;

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
            this.GruvBoxThemeCommand = new DelegateCommand(this.OnGruvBoxThemeCommand);
            this.SolarizedThemeCommand = new DelegateCommand(this.OnSolarizedThemeCommand);
        }

        private void Initialize()
        {
            this.WindowTitle = Strings.WindowTitle;
            this.ToolNameLabel = Strings.ToolNameLabel;
            this.ToolNumberLabel = Strings.ToolNumberLabel;
            this.ToolDiameterLabel = Strings.ToolDiameterLabel;
            this.ToolLengthOffsetLabel = Strings.ToolLengthOffsetLabel;
            this.ToolDiameterOffsetLabel = Strings.ToolDiameterOffsetLabel;
            this.FeedRateLabel = Strings.FeedRateLabel;
            this.SpindleSpeedLabel = Strings.SpindleSpeedLabel;
            this.CoolantLabel = Strings.CoolantLabel;
            this.ToolPlaneLabel = Strings.ToolPlaneLabel;
            this.WorkOffsetLabel = Strings.WorkOffsetLabel;

            this.ContextMenuThemes = Strings.ContextMenuThemes;
            this.ContextMenuLight = Strings.ContextMenuLight;
            this.ContextMenuDark = Strings.ContextMenuDark;
            this.ContextMenuGruvBox = Strings.ContextMenuGruvBox;
            this.ContextMenuSolarized = Strings.ContextMenuSolarized;

            this.OnLightThemeCommand(null);
        }

        #endregion

        #region Commands

        public ICommand LightThemeCommand { get; }

        public ICommand DarkThemeCommand { get; }

        public ICommand GruvBoxThemeCommand { get; }

        public ICommand SolarizedThemeCommand { get; }

        #endregion

        #region Public Properties

        public string WindowTitle { get; set; }
        
        public string ContextMenuThemes { get; set; }

        public string ContextMenuLight { get; set; }

        public string ContextMenuDark { get; set; }

        public string ContextMenuGruvBox { get; set; }

        public string ContextMenuSolarized { get; set; }        

        public string ToolNameLabel { get; set; }

        public string ToolNumberLabel { get; set; }

        public string ToolDiameterLabel { get; set; }

        public string ToolLengthOffsetLabel { get; set; }

        public string ToolDiameterOffsetLabel { get; set; }
        
        public string FeedRateLabel { get; set; }

        public string SpindleSpeedLabel { get; set; }

        public string CoolantLabel { get; set; }

        public string ToolPlaneLabel
        {
        get => this.toolPlaneLabel;

            set
            {
                this.toolPlaneLabel = value;
                OnPropertyChanged(nameof(this.ToolPlaneLabel));
            }
        }

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

        public SolidColorBrush HeadingBrush
        {
            get => this.headingBrush;

            set
            {
                this.headingBrush = value;
                OnPropertyChanged(nameof(this.HeadingBrush));
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

        public SolidColorBrush ParameterBrush
        {
            get => this.parameterBrush;

            set
            {
                this.parameterBrush = value;
                OnPropertyChanged(nameof(this.ParameterBrush));
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

        public string ToolNumber
        {
            get => toolNumber;

            set
            {
                toolNumber = value;
                OnPropertyChanged(nameof(ToolNumber));
            }
        }

        public string ToolDiameter
        {
            get => toolDiameter;

            set
            {
                toolDiameter = value;
                OnPropertyChanged(nameof(ToolDiameter));
            }
        }

        public string ToolLengthOffset
        {
            get => toolLengthOffset;

            set
            {
                toolLengthOffset = value;
                OnPropertyChanged(nameof(ToolLengthOffset));
            }
        }

        public string ToolDiameterOffset
        {
            get => toolDiameterOffset;

            set
            {
                toolDiameterOffset = value;
                OnPropertyChanged(nameof(ToolDiameterOffset));
            }
        }

        public string Feedrate
        {
            get => feedrate;

            set
            {
                feedrate = value;
                OnPropertyChanged(nameof(Feedrate));
            }
        }

        public string SpindleSpeed
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
            ClearParameters();

            if (operation != null)
            {
                this.OperationHeading = $"{GetOperationDescription(operation.Type)}{Environment.NewLine}" +
                                        $"{operation.Name}";

                if (operation.OperationTool != null)
                {
                    this.ToolName = operation.OperationTool.Name;
                    this.ToolNumber = operation.OperationTool.Number.ToString();
                    this.ToolDiameter = operation.OperationTool.Diameter.ToString("#.######");
                    this.ToolLengthOffset = operation.OperationTool.LengthOffset.ToString();
                    this.ToolDiameterOffset = operation.OperationTool.DiameterOffset.ToString();
                }

                this.Feedrate = operation.FeedRate.ToString("#.######");
                this.SpindleSpeed = operation.SpindleSpeed.ToString("#.######");

                SetCoolantToolPlaneWorkOffset(operation);
            }

            return null;
        }

        private void ClearParameters()
        {
            this.ToolPlaneLabel = Strings.ToolPlaneLabel;

            this.OperationHeading = string.Empty;
            this.ToolName = Strings.NoData;
            this.ToolNumber = Strings.NoData;
            this.ToolDiameter = Strings.NoData;
            this.ToolLengthOffset = Strings.NoData;
            this.ToolDiameterOffset = Strings.NoData;
            this.Feedrate = Strings.NoData;
            this.SpindleSpeed = Strings.NoData;
            this.Coolant = Strings.NoData;
            this.ToolPlane = Strings.NoData;
            this.WorkOffset = Strings.NoData;
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
                case 103:
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
                    return Strings.StockModelOperation;

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

        private void SetCoolantToolPlaneWorkOffset(Operation operation)
        {
            switch ((int)operation.Type)
            {
                case 4:
                case 17:
                case 154:
                case 155:
                    break;

                case 20:
                case 103:
                    this.ToolPlane = operation.ToolPlane.ViewName;
                    this.WorkOffset = GetWorkOffset(operation.ToolPlane.WorkOffsetNumber);
                    break;

                case 139:
                    this.ToolPlaneLabel = Strings.StockPlane;
                    this.ToolPlane = operation.ToolPlane.ViewName;
                    break;

                case 150:
                case 151:
                case 152:
                case 153:
                    this.ToolPlane = operation.ToolPlane.ViewName;
                    this.WorkOffset = GetWorkOffset(operation.ToolPlane.WorkOffsetNumber);
                    break;

                default:
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
                    break;
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
            var background = Color.FromRgb(30, 30, 30);
            var heading = Color.FromRgb(78, 201, 176);
            var labels = Color.FromRgb(86, 156, 214);
            var parameters = Color.FromRgb(200, 200, 200);

            SetTheme(background, heading, labels, parameters);
        }

        private void OnGruvBoxThemeCommand(object parameter)
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
            this.HeadingBrush = new SolidColorBrush(heading);
            this.LabelBrush = new SolidColorBrush(labels);
            this.ParameterBrush = new SolidColorBrush(parameters);
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