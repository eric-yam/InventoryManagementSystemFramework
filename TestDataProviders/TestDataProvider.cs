using System.Text.Json;
using InventoryManagementSystemFramework.TestDataWorkflows;

namespace InventoryManagementSystemFramework.TestDataProviders
{
    public class TestDataProvider
    {

        public static IEnumerable<T> TestCaseDataProvider<T>(string jsonString)
        {
            List<T>? deserializedList = JsonSerializer.Deserialize<List<T>>(jsonString);
            if (deserializedList != null)
            {
                foreach (T currentTestDataModel in deserializedList)
                {
                    yield return currentTestDataModel;
                }
            }
        }

        public static IEnumerable<HomeDashBoardWorkflow> HomeDashBoardWorkflowDataProvider()
        {
            string jsonString = File.ReadAllText("Resources\\verify_home_dash_workflow_test_data.json");
            return TestCaseDataProvider<HomeDashBoardWorkflow>(jsonString);
        }

        public static IEnumerable<NavBarWorkflow> SideBarNavDataProvider()
        {
            string jsonString = File.ReadAllText("Resources\\nav_bar_all_links_workflow_test_data.json");
            return TestCaseDataProvider<NavBarWorkflow>(jsonString);
        }

        public static IEnumerable<NavBarWorkflow> NavBarWorkflowDataProvider()
        {
            string jsonString = File.ReadAllText("Resources\\nav_bar_workflow_test_data.json");
            return TestCaseDataProvider<NavBarWorkflow>(jsonString);
        }

        public static IEnumerable<AddNewItemWorkflow> AddNewItemWorkflowDataProvider()
        {
            string jsonString = File.ReadAllText("Resources\\add_new_item_workflow_test_data.json");
            return TestCaseDataProvider<AddNewItemWorkflow>(jsonString);
        }


        public static IEnumerable<T> TestDataProviderSingle<T>(string jsonString)
        {
            // List<T>? deserializedList = JsonSerializer.Deserialize<List<T>>(jsonString);
            // if (deserializedList != null)
            // {
            //     foreach (T currentTestDataModel in deserializedList)
            //     {
            //         yield return currentTestDataModel;
            //     }
            // }
            // JsonSerializer.Deserialize<AddItemGroupWorkflow>(jsonString);


            T? temp = JsonSerializer.Deserialize<T>(jsonString);
            yield return temp;
        }
        public static IEnumerable<AddItemGroupWorkflow> AddItemGroupWorkflowDataProvider()
        {
            string jsonString = File.ReadAllText("Resources\\add_new_item_group_workflow_test_data.json");
            return TestDataProviderSingle<AddItemGroupWorkflow>(jsonString);
            // AddItemGroupWorkflow? temp = JsonSerializer.Deserialize<AddItemGroupWorkflow>(jsonString);
            // yield return temp;
            // return TestDataProviderSingle<AddItemGroupWorkflow>(jsonString);
        }
    }
}
