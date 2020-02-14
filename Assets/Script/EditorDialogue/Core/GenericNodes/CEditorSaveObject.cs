using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace DNECore {

    //Los Scriptable object almacenan informacion de los objetos
    /*
     * El ScriptableObject es una clase que le permite a usted almacenar grandes cantidades de datos compartidos independientes de instancias de script. 
     * No confunda esta clase con la muy similar SerializableObject, la cual es una clase del editor y llena un propósito diferente.
     * Considere por ejemplo que usted ha hecho un prefab con un script que tiene un arreglo de millones de enteros.
     * El arreglo ocupa 4MB de memoria y su dueño es el prefab. Cada vez que usted instancia el prefab, 
     * usted va a obtener una copia de ese arreglo. Si usted ha creado 10 game objects, entonces usted terminaría con 40MB de datos del arreglo para las 10 instancias.

Unity serializa todos los tipos primitivos, strings, arreglos, listas, 
tipos específicos para Unity tal como Vector3 y sus clases personalizadas con el atributo Serializable como copies perteneciendo al objeto en el cual fue declarado. 
Esto significa que si usted ha creado un ScriptableObject y almacena millones de enteros en un arreglo, entonces declara que el arreglo será almacenado con la instancia.
Las instancias son pensadas en sus propios datos individuales. Los campos ScriptableObject, o cualquier
campo UnityEngine.Object, tal como MonoBehaviour, Mesh, GameObject y así, son almacenados por referencia opuesto a un valor. 
Si usted tiene un script con una referencia al ScriptableObject con un millón de enteros, Unity va a solamente guardar una referencia al ScriptableObject en los datos de script. 
El ScriptableObject por el contrario, almacenada el arreglo. 10 instancias de un prefab que tiene una referencia ScriptableObject , que mantiene 4MB de datos,
va a pesar en total 4MB y no 40MB como se discutio en el otro ejemplo.

El caso intencionado para utilizar el ScriptableObject es reducir el uso de memoria al evitar la copias de valores,
pero usted también puede utilizarlo para definir conjuntos de datos conecta-bles. 
Un ejemplo de esto sería imaginar una tienda NPC en un juego RPG. Usted puede crear múltiples assets de su ScriptableObject ShopContents personalizado, 
cada uno definiendo un conjunto de items que están disponibles para compra. En un escenario dónde el juego tiene tres zonas, 
cada zona puede ofrecer diferentes tipos de items. El script de su tienda podría referenciar un objeto ShopContents que define qué items están disponibles.
Por favor ver la referencia de scripting para ejemplos.

Once you have defined a ScriptableObject-derived class, you can use the CreateAssetMenu attribute to make it easy to create custom assets using your class.

Recomendación: Cuando trabaje con referencias ScriptableObject en el inspector, 
usted puede hacer doble click en el campo de referencia para abrir el inspector para su ScriptableObject. 
Usted también puede crear un editor personalizado para definir el aspecto del inspector para su tipo para ayudar a manejar los datos que representa.
     * */
    public class CEditorSaveObject : ScriptableObject
{
        public List<NodeInfo> nodeinfos;
        public List<int> NodeCPindex;
        public List<int> ConnectionIndexIn;
        public List<int> ConnectionIndexOut;
        public int NumberOfCP;
        public Vector2 offset;
        
        public void init(List<NodeInfo> nodeinfos, List<int> NodeCPindex,List<int> ConnectionIndexIn, List<int> ConnectionIndexOut, int NumberOfCP, Vector2 offset)
        {
            this.nodeinfos = nodeinfos;
            this.NodeCPindex = NodeCPindex;
            this.ConnectionIndexIn = ConnectionIndexIn;
            this.ConnectionIndexOut = ConnectionIndexOut;
            this.NumberOfCP = NumberOfCP;
            this.offset = offset;
        }
 
}

    [Serializable]
    public class NodeInfo
    {
        public string type;
        public Rect rect;
        public string title;
        public string text;
        public List<string> triggers;

        public NodeInfo(string type, Rect rect, string title = null,string text = null,List<string> triggers = null)
        {
            this.type = type;
            this.rect = rect;
            this.title = title;
            this.text = text;
            this.triggers = triggers;
        }
    }

}
