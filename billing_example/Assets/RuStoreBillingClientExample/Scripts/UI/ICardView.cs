using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RuStore.Example.UI {

    public interface ICardView<T> {

        T GetData();
        void SetData(T value);
    }
}
