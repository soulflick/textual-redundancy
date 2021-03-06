#pragma checksum "..\..\..\..\Controls\TokenControl.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FF5B06C477BD49C7A492F41F95530C741BBE705EC6527D925A836BCAA40F5384"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace TextualRedundancy.Controls {
    
    
    /// <summary>
    /// TokenControl
    /// </summary>
    public partial class TokenControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GraphBorder;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GridBorder;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ValueGrid;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnToken;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnLength;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnPosition;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnImpact;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnDistribution;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\..\Controls\TokenControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTemplateColumn ColumnCount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TextualRedundancy;component/controls/tokencontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\TokenControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GraphBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.GridBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.ValueGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 40 "..\..\..\..\Controls\TokenControl.xaml"
            this.ValueGrid.KeyUp += new System.Windows.Input.KeyEventHandler(this.ValueGrid_KeyUp);
            
            #line default
            #line hidden
            
            #line 41 "..\..\..\..\Controls\TokenControl.xaml"
            this.ValueGrid.Sorting += new System.Windows.Controls.DataGridSortingEventHandler(this.ValueGrid_Sorting);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ColumnToken = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 5:
            this.ColumnLength = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 6:
            this.ColumnPosition = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 7:
            this.ColumnImpact = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 8:
            this.ColumnDistribution = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            case 9:
            this.ColumnCount = ((System.Windows.Controls.DataGridTemplateColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

