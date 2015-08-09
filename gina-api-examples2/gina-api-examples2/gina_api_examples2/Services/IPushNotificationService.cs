using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gina_api_examples2.Core.Services
{
    public interface IPushNotificationService
    {
        void StartService();

        void StopService();
    }
}
