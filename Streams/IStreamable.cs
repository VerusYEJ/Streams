using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    public interface IStreamable
    {
       void StartStream();

        void StopStream();
    }
}
