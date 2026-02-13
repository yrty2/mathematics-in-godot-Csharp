using Godot;
using System;

namespace mathematics;
public class Mdi{
	//数学定数
	public const double e=Math.E;
	public const double pi=Math.PI;
	public static readonly Complex cone=new Complex(1,0);
	public static readonly Complex czero=new Complex(0,0);
	public static readonly Complex i=new Complex(0,1);
	//初等関数やオーバーロードなど
	public static double sqrt(double a)=>
		Math.Sqrt(a);
	public static double abs(double a)=>
		Math.Abs(a);
	public static double abs(Complex a)=>
		a.z.length;
	public static double abs(Quat a)=>
		a.q.length;
	public static double sin(double a)=>
		Math.Sin(a);
	public static Complex sin(Complex a)=>
		(Mdi.exp(Mdi.i*a)-Mdi.exp(-Mdi.i*a))*new Complex(0,-1/2);
	public static double cos(double a)=>
		Math.Cos(a);
	public static Complex cos(Complex a)=>
		(Mdi.exp(Mdi.i*a)+Mdi.exp(-Mdi.i*a))/2;
	public static double tan(double a)=>
		Math.Tan(a);
	public static double asin(double a)=>
		Math.Asin(a);
	public static double acos(double a)=>
		Math.Acos(a);
	public static double atan(double a)=>
		Math.Atan(a);
	public static double sinh(double a)=>
		Math.Sinh(a);
	public static Complex sinh(Complex a)=>
		(Mdi.exp(a)-Mdi.exp(-a))/2;
	public static double cosh(double a)=>
		Math.Cosh(a);
	public static Complex cosh(Complex a)=>
		(Mdi.exp(a)+Mdi.exp(-a))/2;
	public static double tanh(double a)=>
		Math.Tanh(a);
	public static Complex tanh(Complex a){
		Complex ez=Mdi.exp(a);
		Complex mez=Mdi.exp(-a);
		return (ez-mez)/(ez+mez);
	}
	public static double asinh(double a)=>
		Math.Asinh(a);
	public static double acosh(double a)=>
		Math.Acosh(a);
	public static double atanh(double a)=>
		Math.Atanh(a);
	public static double atan2(double a,double b)=>
		Math.Atan2(a,b);
	public static double max(double a,double b)=>Math.Max(a,b);
	public static double min(double a,double b)=>Math.Min(a,b);
	public static float min(float a,float b)=>Math.Min(a,b);
	public static double dot(Vector a,Vector b){
		double res=0;
		for(int k=0; k<Mdi.max(a.dim,b.dim); ++k){
			res+=a[k]*b[k];
		}
		return res;
	}
	public static double dot(vec2 a,vec2 b)=>
	a.x*b.x+a.y*b.y;
	public static double dot(vec3 a,vec3 b)=>
	a.x*b.x+a.y*b.y+a.z*b.z;
	public static double dot(vec4 a,vec4 b)=>
	a.x*b.x+a.y*b.y+a.z*b.z+a.w*b.w;
	public static double cross(vec2 a,vec2 b)=>
	a.x*b.y-a.y*b.x;
	public static vec3 cross(vec3 a,vec3 b)=>
	new vec3(a.y*b.z-a.z*b.y,a.z*b.x-a.x*b.z,a.x*b.y-a.y*b.x);
	public static Complex conj(Complex a)=>
	new Complex(a.real,-a.imag);
	public static double arg(Complex a)=>
	Math.Atan2(a.imag,a.real);
	public static double arg(vec2 a)=>
	Math.Atan2(a.y,a.x);
	public static Vector normalize(Vector a){
		double r=a.length;
		if(r==0){
			return new Vector(a.dim);
		}
		return a/r;
	}
	public static vec2 normalize(vec2 a){
		double r=a.length;
		if(r==0){
			return new vec2(0,0);
		}
		return a/r;
	}
	public static vec3 normalize(vec3 a){
		double r=a.length;
		if(r==0){
			return new vec3(0,0,0);
		}
		return a/r;
	}
	public static vec4 normalize(vec4 a){
		double r=a.length;
		if(r==0){
			return 0;
		}
		return a/r;
	}
	public static Complex normalize(Complex a){
		double r=abs(a);
		if(r==0){
			return 0;
		}
		return a/r;
	}
	public static Quat normalize(Quat a){
		double r=abs(a);
		if(r==0){
			return 0;
		}
		return a/r;
	}
	public static double exp(double a)=>Math.Exp(a);
	public static Complex exp(Complex a)=>Math.Exp(a.real)*new Complex(Mdi.cos(a.imag),Mdi.sin(a.imag));
	public static Quat exp(Quat a){
		double abs=a.imag.length;
		double sin=Mdi.sin(abs)/abs;
		return Math.Exp(a.real)*new Quat(Mdi.cos(abs),a.i*sin,a.j*sin,a.k*sin);
	}
	public static double ln(double a)=>Math.Log(a);
	public static Complex ln(Complex a)=>new Complex(Math.Log(Mdi.dot(a.z,a.z))/2,Mdi.arg(a));
	public static Complex poler(double radius,double theta)=>radius*new Complex(Mdi.cos(theta),Mdi.sin(theta));
	public static double pow(double a,double b)=>Math.Pow(a,b);
	public static Complex pow(Complex a,double b)=>Mdi.poler(Math.Pow(Mdi.abs(a),b),b*Mdi.arg(a));
	public static Complex pow(Complex a,Complex b){
		//a^b=e^(blna)
		return Mdi.exp(b*Mdi.ln(a));
	}
	public static Complex pow(double a,Complex b){
		//a^b=e^(blna)
		return Mdi.exp(b*Mdi.ln(a));
	}
}

public struct vec2{
	public double x;
	public double y;
	public const int dim=2;
	public vec2(double X,double Y){
		x=X;
		y=Y;
	}
	
	public static implicit operator vec2(double a)=>
	new vec2(a,a);
	
	public static implicit operator vec2((double,double) t) =>
	new vec2(t.Item1,t.Item2);
	
	public static vec2 operator +(vec2 a, vec2 b)=>
	new vec2(a.x+b.x,a.y+b.y);
	public static vec2 operator -(vec2 a, vec2 b)=>
	new vec2(a.x-b.x,a.y-b.y);
	public static vec2 operator -(vec2 a)=>
	new vec2(-a.x,-a.y);
	public static vec2 operator *(vec2 a, vec2 b)=>
	new vec2(a.x*b.x,a.y*b.y);
	public static vec2 operator /(vec2 a, vec2 b)=>
	new vec2(a.x/b.x,a.y/b.y);
	public static double operator |(vec2 a, vec2 b)=>
	Mdi.dot(a,b);
	public static double operator ^(vec2 a, vec2 b)=>
	Mdi.cross(a,b);
	public double length=>Math.Sqrt(x*x+y*y);
	public vec3 extend(double a)=>
		new vec3(x,y,a);
	public override string ToString() => $"({x},{y})";
}
public struct vec3{
	public double x;
	public double y;
	public double z;
	public const int dim=3;
	public vec3(double X,double Y,double Z){
		x=X;
		y=Y;
		z=Z;
	}
	
	public static implicit operator vec3(double a) =>
	new vec3(a,a,a);
	
	public static implicit operator vec3(vec2 a) =>
	new vec3(a,0);
	
	public static implicit operator vec3((double,double,double) t) =>
	new vec3(t.Item1,t.Item2,t.Item3);
	
	//二項演算
	public static vec3 operator +(vec3 a, vec3 b)=>
	new vec3(a.x+b.x,a.y+b.y,a.z+b.z);
	public static vec3 operator -(vec3 a, vec3 b)=>
	new vec3(a.x-b.x,a.y-b.y,a.z-b.z);
	public static vec3 operator -(vec3 a)=>
	new vec3(-a.x,-a.y,-a.z);
	public static vec3 operator *(vec3 a, vec3 b) =>
	new vec3(a.x*b.x,a.y*b.y,a.z*b.z);
	public static vec3 operator /(vec3 a, vec3 b) =>
	new vec3(a.x/b.x,a.y/b.y,a.z/b.z);
	public static vec3 operator ^(vec3 a, vec3 b) =>
	Mdi.cross(a,b);
	public static double operator |(vec3 a, vec3 b) =>
	Mdi.dot(a,b);
	
	public double length=>Math.Sqrt(x*x+y*y+z*z);
	//スウィズル
	public vec3(vec2 v,double Z){
		x=v.x;
		y=v.y;
		z=Z;
	}
	public vec3(double X,vec2 v){
		x=X;
		y=v.x;
		z=v.y;
	}
	public vec2 xy{
		get=>new vec2(x,y);
		set{
			x=value.x;
			y=value.y;
		}
	}
	public vec2 yz{
		get=>new vec2(y,z);
		set{
			y=value.x;
			z=value.y;
		}
	}
	public vec2 zx{
		get=>new vec2(z,x);
		set{
			z=value.x;
			x=value.y;
		}
	}
	public vec2 yx{
		get=>new vec2(y,x);
		set{
			y=value.x;
			x=value.y;
		}
	}
	public vec2 zy{
		get=>new vec2(z,y);
		set{
			z=value.x;
			y=value.y;
		}
	}
	public vec2 xz{
		get=>new vec2(x,z);
		set{
			x=value.x;
			z=value.y;
		}
	}
	public override string ToString() => $"({x},{y},{z})";
}
public struct vec4{
	public double x;
	public double y;
	public double z;
	public double w;
	public const int dim=4;
	public vec4(double X,double Y,double Z,double W){
		x=X;
		y=Y;
		z=Z;
		w=W;
	}
	
	public static implicit operator vec4(double a) =>
	new vec4(a,a,a,a);
	
	public static implicit operator vec4(vec2 a) =>
	new vec4(a,0,0);
	
	public static implicit operator vec4(vec3 a) =>
	new vec4(a,0);
	
	public static implicit operator vec4((double,double,double,double) t) =>
	new vec4(t.Item1,t.Item2,t.Item3,t.Item4);
	
	//二項演算
	public static vec4 operator +(vec4 a, vec4 b)=>
	new vec4(a.x+b.x,a.y+b.y,a.z+b.z,a.w+b.w);
	public static vec4 operator -(vec4 a, vec4 b)=>
	new vec4(a.x-b.x,a.y-b.y,a.z-b.z,a.w-b.w);
	public static vec4 operator -(vec4 a)=>
	new vec4(-a.x,-a.y,-a.z,-a.w);
	public static vec4 operator *(vec4 a, vec4 b) =>
	new vec4(a.x*b.x,a.y*b.y,a.z*b.z,a.w*b.w);
	public static vec4 operator /(vec4 a, vec4 b) =>
	new vec4(a.x/b.x,a.y/b.y,a.z/b.z,a.w/b.w);
	public static double operator |(vec4 a, vec4 b) =>
	Mdi.dot(a,b);
	
	public double length=>Math.Sqrt(x*x+y*y+z*z+w*w);
	//スウィズル
	public vec4(vec2 v,double a,double b){
		x=v.x;
		y=v.y;
		z=a;
		w=b;
	}
	public vec4(double a,vec2 v,double b){
		x=a;
		y=v.x;
		z=v.y;
		w=b;
	}
	public vec4(double a,double b,vec2 v){
		x=a;
		y=b;
		z=v.x;
		w=v.y;
	}
	public vec4(vec2 u,vec2 v){
		x=u.x;
		y=u.y;
		z=v.x;
		w=v.y;
	}
	public vec4(vec3 v,double a){
		x=v.x;
		y=v.y;
		z=v.z;
		w=a;
	}
	public vec4(double a,vec3 v){
		x=a;
		y=v.x;
		z=v.y;
		w=v.z;
	}
	public vec3 xyz{
		get=>new vec3(x,y,z);
		set{
			x=value.x;
			y=value.y;
			z=value.z;
		}
	}
	public vec3 yzw{
		get=>new vec3(y,z,w);
		set{
			y=value.x;
			z=value.y;
			w=value.z;
		}
	}
	public vec3 zwx{
		get=>new vec3(z,w,x);
		set{
			z=value.x;
			w=value.y;
			x=value.z;
		}
	}
	public vec3 wxy{
		get=>new vec3(w,x,y);
		set{
			w=value.x;
			x=value.y;
			y=value.z;
		}
	}
	public override string ToString() => $"({x},{y},{z},{w})";
}
public struct Vector{
	double[] data;
	public double[] raw=>data;
	public int dim=>data.Length;
	public double length=>Mdi.sqrt(Mdi.dot(this,this));
	public Vector(int a){
		data=new double[a];
	}
	public Vector(params double[] values){
		data=values;
	}
	public double this[int i]{
		get{
			if(i<dim){
				return data[i];
			}
			return 0;
		}
		set=>data[i]=value;
	}
	public static implicit operator Vector(double x)=>
	new Vector(x);
	public static implicit operator Vector((double,double) t)=>
	new Vector(t.Item1,t.Item2);
	public static implicit operator Vector((double,double,double) t)=>
	new Vector(t.Item1,t.Item2,t.Item3);
	public static implicit operator Vector((double,double,double,double) t)=>
	new Vector(t.Item1,t.Item2,t.Item3,t.Item4);
	public static implicit operator Vector((double,double,double,double,double) t)=>
	new Vector(t.Item1,t.Item2,t.Item3,t.Item4,t.Item5);
	public static implicit operator Vector((double,double,double,double,double,double) t)=>
	new Vector(t.Item1,t.Item2,t.Item3,t.Item4,t.Item5,t.Item6);
	//演算子など
	public static Vector operator +(Vector a,Vector b){
		Vector res=new Vector(Math.Max(a.dim,b.dim));
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]+b[k];
		}
		return res;
	}
	public static Vector operator -(Vector a,Vector b){
		Vector res=new Vector(Math.Max(a.dim,b.dim));
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]-b[k];
		}
		return res;
	}
	public static Vector operator *(Vector a,Vector b){
		Vector res=new Vector(Math.Max(a.dim,b.dim));
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]*b[k];
		}
		return res;
	}
	public static Vector operator *(Vector a,double b){
		Vector res=new Vector(a.dim);
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]*b;
		}
		return res;
	}
	public static Vector operator *(double a,Vector b){
		Vector res=new Vector(b.dim);
		for(int k=0; k<res.dim; ++k){
			res[k]=a*b[k];
		}
		return res;
	}
	public static Vector operator /(Vector a,Vector b){
		Vector res=new Vector(Math.Max(a.dim,b.dim));
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]/b[k];
		}
		return res;
	}
	public static Vector operator /(Vector a,double b){
		Vector res=new Vector(a.dim);
		for(int k=0; k<res.dim; ++k){
			res[k]=a[k]/b;
		}
		return res;
	}
	public static double operator |(Vector a,Vector b)=>Mdi.dot(a,b);
	public override string ToString()=>"("+string.Join(",",data)+")";
}

public struct Complex{
	public vec2 z;

	public Complex(double real, double imag){
		z=new vec2(real,imag);
	}
	public Complex(vec2 Z){
		z=Z;
	}
	//いいのかねぇ...
	public static implicit operator Complex(double real)=>
	new Complex(real,0);
	
	public static implicit operator Complex((double,double) t) =>
	new Complex(t.Item1,t.Item2);
	
	public double real=>z.x;
	public double imag=>z.y;
	
	public static Complex operator +(Complex a, Complex b)=>
	new Complex(a.z+b.z);
	public static Complex operator -(Complex a, Complex b)=>
	new Complex(a.z-b.z);
	public static Complex operator -(Complex a)=>
	new Complex(-a.z);
	public static Complex operator *(Complex a, Complex b)=>
	new Complex(a.real*b.real-a.imag*b.imag,a.real*b.imag+a.imag*b.real);
	public static Complex operator *(Complex a, double b)=>
	new Complex(b*a.real,b*a.imag);
	public static Complex operator *(double a, Complex b)=>
	new Complex(a*b.real,a*b.imag);
	public static Complex operator /(Complex a, Complex b)=>
	a*~b/Mdi.dot(b.z,b.z);
	public static Complex operator /(Complex a, double b)=>
	new Complex(a.real/b,a.imag/b);
	public static Complex operator ~(Complex a)=>
	Mdi.conj(a);
	public static Complex operator ^(Complex a,Complex b)=>
	Mdi.pow(a,b);
	public static Complex operator ^(Complex a,double b)=>
	Mdi.pow(a,b);
	public static Complex operator ^(double a,Complex b)=>
	Mdi.pow(a,b);

	public override string ToString() => $"{z.x}+{z.y}i";
}
public struct Quat{
	public vec4 q;

	public Quat(double real, double i,double j,double k){
		q=new vec4(real,i,j,k);
	}
	public Quat(double real,vec3 v){
		q=new vec4(real,v.x,v.y,v.z);
	}
	public Quat(vec4 Q){
		q=Q;
	}
	public Quat(Complex v){
		q=new vec4(v.real,v.imag,0,0);//所説あり
	}
	public static implicit operator Quat(double real)=>
	new Quat(real,0,0,0);
	public static implicit operator Quat((double,double,double,double) t)=>
	new Quat(t.Item1,t.Item2,t.Item3,t.Item4);
	
	public double real=>q.x;
	public vec3 imag=>new vec3(q.y,q.z,q.w);
	public double i=>q.y;
	public double j=>q.z;
	public double k=>q.w;
	
	public static Quat operator +(Quat a,Quat b)=>
	new Quat(a.q+b.q);
	public static Quat operator -(Quat a,Quat b)=>
	new Quat(a.q-b.q);
	public static Quat operator -(Quat a)=>
	new Quat(-a.q);
	public static Quat operator *(Quat a,Quat b)=>
	new Quat(a.real*b.q+new vec4(-(a.q.yzw|b.q.yzw),a.q.yzw^b.q.yzw)+b.real*a.q.yzw);
	public static Quat operator *(Quat a,double b)=>
	new Quat(a.q*b);
	public static Quat operator *(double a,Quat b)=>
	new Quat(a*b.q);
	public static Quat operator /(Quat a,double b)=>
	new Quat(a.q/b);

	public override string ToString() => $"{q.x}+{q.y}i+{q.z}j+{q.w}k";
}
