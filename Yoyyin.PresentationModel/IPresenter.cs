using System.Collections.Generic;

namespace Yoyyin.PresentationModel
{
    public interface IPresenter<T>
    {
        IPresentation Presentate(T shouldBeConverted);
        IEnumerable<IPresentation> Presentate(IEnumerable<T> shouldBeConverted);
    }
}
