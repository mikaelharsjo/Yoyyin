using System.Collections.Generic;
using System.Linq;

namespace Yoyyin.PresentationModel
{
    public abstract class GenericPresenter<T> : IPresenter<T>
    {
        public abstract IPresentation Presentate(T shouldBeConverted);

        public IEnumerable<IPresentation> Presentate(IEnumerable<T> shouldBeConverted)
        {
            return shouldBeConverted.Select(Presentate);
        }
    }
}