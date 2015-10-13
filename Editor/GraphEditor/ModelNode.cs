﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor;

public class ModelNode<T> : BaseNode{
    T t;
    public List<T> models = new List<T>();
    public List<int> intModels = null;
    public List<float> floatModels = null;
    public List<string> stringModels = null;
    public ModelNode(T t) : base(){
        this.t = t;
        models.Add( t );
        GraphTitle = "ModelNode";
        GraphType = NodeType.Model;
    }

    
    public override void DrawGraph( int id )
    {
        base.DrawGraph( id );
        EditorGUILayout.BeginHorizontal();
        if( GUILayout.Button( "Add " + t.GetType() ) ){
            models.Add(t);
        }
        if( GUILayout.Button( "Sub" ) )
        {
            models.RemoveAt( models.Count - 1 );
            models.TrimExcess();
        }
        EditorGUILayout.EndHorizontal();
        for (int i = 0; i < models.Count; i++){
            if( t is string ){
                List<string> std = models as List<string>;
                std[i] = EditorGUILayout.TextField( std[i] );
            }
            else if( t is int ){
                List<int> std = models as List<int>;
                std[i] = EditorGUILayout.IntField( std[i] );
            }
            else if( t is float ){
                List<float> std = models as List<float>;
                std[i] = EditorGUILayout.FloatField( std[i] );
            }
		}
    }



    public void SetValue( T t ){

    }

    

}
