using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SpawnDev.Blazor.UnitTesting {
    public partial class UnitTestsView : IDisposable {
        UnitTestRunner unitTestService { get; set; } = new UnitTestRunner();

        [Parameter]
        public IEnumerable<Type>? TestTypes { get; set; }

        [Parameter]
        public IEnumerable<Assembly>? TestAssemblies { get; set; }

        [Parameter]
        public Func<Type, object?>? TypeInstanceResolver { get; set; }

        [Inject]
        IServiceProvider ServiceProvider { get; set; }

        [Inject]
        IServiceCollection ServiceDescriptors { get; set; }

        bool _beenInit = false;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            LoadFromParams();
        }

        public UnitTestsView()
        {
            unitTestService.OnUnitTestResolverEvent += UnitTestService_OnUnitTestResolverEvent;
        }

        private void UnitTestService_OnUnitTestResolverEvent(UnitTestResolverEvent resolverEvent)
        {
            resolverEvent.TypeInstance = TypeInstanceResolver?.Invoke(resolverEvent.TestType);
            resolverEvent.TypeInstance ??= ServiceProvider.GetService(resolverEvent.TestType);
        }

        void LoadFromParams()
        {
            var types = new List<Type>();
            if (TestTypes != null) types.AddRange(TestTypes);
            if (TestAssemblies != null)
            {
                var testClassTypes = TestAssemblies.SelectMany(o => o.GetTypes()).Where(o => o.GetCustomAttribute<TestClassAttribute>() != null).ToList();
                types.AddRange(testClassTypes);
            }
            unitTestService.SetTestTypes(types);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (!_beenInit)
            {
                _beenInit = true;
                unitTestService.TestStatusChanged += UnitTestSet_TestStatusChanged;
            }
        }

        private void UnitTestSet_TestStatusChanged() {
            StateHasChanged();
        }

        public void Dispose() {
            if (_beenInit ) {
                _beenInit = false;
                unitTestService.CancelTests();
                unitTestService.TestStatusChanged -= UnitTestSet_TestStatusChanged;
            }
        }
    }
}
