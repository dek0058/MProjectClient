using UnityEditor;
using MProject.Animation;
using MProject.Player;


[CustomPropertyDrawer(typeof(AnimationDictionary))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer { }
