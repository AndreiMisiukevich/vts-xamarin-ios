using System.Collections.Generic;
using Epam.Vts.Xamarin.Core.CrossCutting;

namespace Epam.Vts.Xamarin.Core.Data.DAC
{
    public abstract class AbstractAccessComponent<TComponent>
    {
        private readonly IConnectionProvider _connectionProvider;
        private bool _isInited;
        protected readonly ISqLite SqLite;
        protected readonly IRestService RestService;
        protected Dictionary<bool, TComponent> InernetConnectionStates;

        protected AbstractAccessComponent(IConnectionProvider connectionProvider, ISqLite sqLite, IRestService restService)
        {
            _connectionProvider = connectionProvider;
            SqLite = sqLite;
            RestService = restService;
        }

        protected abstract void InitConnectionStates();

        protected TComponent CurrentState
        {
            get
            {
                if (!_isInited)
                {
                    _isInited = true;
                    InitConnectionStates();
                }
                var key = _connectionProvider.IsConnected;
                return InernetConnectionStates[key];
            }
        }
    }
}
