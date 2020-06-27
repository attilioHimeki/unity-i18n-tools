using UnityEngine;
using System.Linq;

namespace Himeki.i18n
{
    public abstract class BaseTextFieldLocalisator : BaseLocalisator
    {

        public override void refresh()
        {
            refreshText();
            refreshFont();
        }

        public string getLocalisedText()
        {
            var activeKey = getActiveLocalisationKey();

            return LocalisationManager.instance.getStringForKey(activeKey, parameters);
        }

        public virtual void refreshText()
        { }

        public virtual void refreshFont()
        { }

    }
}