using Godot;
using System;
using System.Collections.Generic;
using mathematics;

public struct easyViz{
    public Node2D node2;
    public Node3D node3;
    public Vector2 window;
    public List<Action> stack = new List<Action>();
    public Geometry geo;
    public easyViz(Geometry Geo,Node2D node,Vector2 screen){
        geo=Geo;
        node2=node;
        window=screen;
    }
    public void point(Vector pos, double r){
        Node2D targetNode=this.node2;
        Vector2 wind=this.window;
        float m=Mdi.min(window.X,window.Y)/2;
        Vector2 scale=new Vector2(m,-m);
        stack.Add(()=>targetNode.DrawCircle(new Vector2(Convert.ToSingle(pos[0]),Convert.ToSingle(pos[1]))*scale+wind/2,Convert.ToSingle(r), Colors.White));
    }
    public void draw(){
        foreach(var act in stack){
            act();
        }
        stack.Clear(); // 描画し終わったら空にする
    }
}
public struct YGPU{
}