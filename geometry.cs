using Godot;
using System;
using mathematics;

public class ProjectiveGeometry{
	public static vec2 perspective(vec3 a)=>a.xy/a.z;
	public static vec3 perspective(vec4 a)=>a.xyz/a.w;
	public static Vector perspective(Vector a)=>ProjectiveGeometry.orthographic(a)/a[a.dim-1];
	public static Vector orthographic(Vector a)=>new Vector(a.raw[0..(a.dim-1)]);
}
public struct Geometry{
	public double curvature;
	public int dim;
	public Geometry(double Curvature,int dimension){
		curvature=Curvature;
		dim=dimension;
	}
	public Vector translate(Vector p,Vector q){
		if(curvature==0){
			return p+q;
		}
		double pp=p|p;
		double pq=p|q;
		double qq=q|q;
		return (q*(1+curvature*pp)+p*(1-curvature*(qq+2*pq)))/(1+curvature*(curvature*pp*qq-2*pq));
	}
	public override string ToString(){
		string geo="Euclidean";
		string adt="";
		if(curvature<0){
			geo="Hyperbolic";
			if(curvature!=-1){
				adt=$"({curvature})";
			}
		}
		if(curvature>0){
			geo="Spherical";
			if(curvature!=1){
				adt=$"({curvature})";
			}
		}
		return $"{dim}-dimensional {geo} Geometry{adt}";
	}
}
public struct MinkowskiSpace{
}
