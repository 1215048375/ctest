using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button1_Click();
        }


        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Send a series of key presses to the Calculator application.
        private void button1_Click()
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow("TXGuiFoundation", "ff");

            // Verify that Calculator is a running process.
            if (calculatorHandle == IntPtr.Zero)
            {
                System.Windows.Forms.MessageBox.Show("qq group is not running.");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
            SendKeys.SendWait("^{v}");
            SendKeys.SendWait("{Enter}");
        }

        // Send a series of key presses to the Calculator application.
        private void button2_Click()
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow("CalcFrame", "计算器");

            // Verify that Calculator is a running process.
            if (calculatorHandle == IntPtr.Zero)
            {
                System.Windows.Forms.MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
        }

        public void test()
        {
            //AutomationElement rootElement = AutomationElement.RootElement;
            //System.Windows.Automation.Condition nameCondition = new PropertyCondition(AutomationElement.NameProperty, "Common Controls Examples");

            //找到Desktop
            AutomationElement Desktop = AutomationElement.RootElement;
            //找到Calculator窗口
            AutomationElement CalcWindows = Desktop.FindFirst(TreeScope.Children,
                            new AndCondition(
                                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                                new PropertyCondition(AutomationElement.ClassNameProperty, "CalcFrame")
                                )
                                );

            if (CalcWindows != null)
            {

                //找到Calculator的Edit控件
                AutomationElement CalcEdit = CalcWindows.FindFirst(TreeScope.Children,
                               new AndCondition(
                                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                                    //new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
                                    new PropertyCondition(AutomationElement.NameProperty, "6")
                                    //new PropertyCondition(AutomationElement.ProcessIdProperty, 3404)
                                    )
                                    );

                if (CalcEdit != null) {

                }
            }
        }
    }
}
