using System;
using System.Windows;
using LACC.Info;

namespace LACC.UI
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * 구현 방안
         * 1. 미리 Content 를 모두 추가해 둔 뒤, 검색 때 정렬
         *  -> Content를 미리 추가해 두므로, 검색 혹은 Expander를 expand할 때 딜레이가 적을 수 있음. 그러나 program init 때 지연이 길 수도?
         *  -> Enum Data 활용 방안 : Enum(ContentName) 형태로 배치 후, 검색하면 UserData에서 Dictionary(Enum, Boolean) 형태로 정리. 후 Content 정렬 등에는 Enum.GetContentName으로 Content 중 검색으로 해결.
         *  -> Enum과 Content의 연결은 init 시에 Dictionary 형태로 저장.
         */

        private bool _initIslandInfo;

        public MainWindow()
        {
            InitializeComponent();
            resetInit();
        }

        private void resetInit()
        {
            _initIslandInfo = false;
        }

        private void islandExpanded(object sender, RoutedEventArgs e)
        {
            if (!_initIslandInfo)
            {
                _initIslandInfo = true;
                Console.WriteLine(EnumManager.GetContent(MindOfIsland.Libeheim));
            }
        }

        private void searchTarget(object sender, RoutedEventArgs e)
        {
            resetInit();
        }

        // 버튼 클릭시 자세한 정보 보여주기
        private void GetMoreInfo(object sender, RoutedEventArgs e)
        {

        }
    }
}
