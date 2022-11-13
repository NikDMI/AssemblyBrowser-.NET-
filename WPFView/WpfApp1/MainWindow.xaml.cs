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

using AssemblyObserver.Model;
using AssemblyObserver.Bean.AssemblyParsing.Assembly;
using AssemblyObserver.Bean.AssemblyParsing.Namespace;
using AssemblyObserver.Bean.AssemblyParsing.Types;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button1.Click += Button_Click;
        }

        internal void ShowAssemblyTree(IAssemblyInfo assemblyInfo)
        {
            assemblyTree.Items.Clear();
            List<INamespaceInfo> namespaces = assemblyInfo.GetAllNamespaces();
            foreach (var namespaceInfo in namespaces)
            {
                TreeViewItem namespaceItem = new TreeViewItem();
                Label lbl = new Label();
                lbl.Content = "namespace " + namespaceInfo.GetNamespaceName();
                namespaceItem.Header = lbl;
                foreach (IType nestedType in namespaceInfo.GetNestedTypes())
                {
                    namespaceItem.Items.Add(GetTreeViewItemByType(nestedType));
                }
                assemblyTree.Items.Add(namespaceItem);
            }
        }


        private TreeViewItem GetTreeViewItemByType(IType type)
        {
            TreeViewItem treeViewItem = new TreeViewItem();
            Label lbl = new Label();
            lbl.Content = type.GetTypeDescription();
            treeViewItem.Header = lbl;
            List<IType> nestedTypes = type.GetNestedTypes();
            if (nestedTypes != null && nestedTypes.Count != 0)
            {
                foreach (IType nestedType in nestedTypes)
                {
                    treeViewItem.Items.Add(GetTreeViewItemByType(nestedType));
                }
            }
            return treeViewItem;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IModel model = ModelFactory.GetModel();
            IAssemblyInfo ass = model.GetAssemblyInfo("D:\\БГУИР 3 КУРС\\СПП\\Labs\\LabWork_2\\FakerLib\\bin\\Debug\\netcoreapp3.1\\FakerLib.dll");
            ShowAssemblyTree(ass);
        }
    }
}
