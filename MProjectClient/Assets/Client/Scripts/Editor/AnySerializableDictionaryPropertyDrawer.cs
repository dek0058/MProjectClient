using UnityEditor;
using MProject.Animation;
using MProject.Player;

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(AnimationDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
#endif