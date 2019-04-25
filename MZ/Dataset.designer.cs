﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MZ
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DB_MZ")]
	public partial class DatasetDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertGryMZ(GryMZ instance);
    partial void UpdateGryMZ(GryMZ instance);
    partial void DeleteGryMZ(GryMZ instance);
    partial void InsertUzytkownicyMZ(UzytkownicyMZ instance);
    partial void UpdateUzytkownicyMZ(UzytkownicyMZ instance);
    partial void DeleteUzytkownicyMZ(UzytkownicyMZ instance);
    #endregion
		
		public DatasetDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DB_MZConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DatasetDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasetDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasetDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DatasetDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<GryMZ> GryMZs
		{
			get
			{
				return this.GetTable<GryMZ>();
			}
		}
		
		public System.Data.Linq.Table<UzytkownicyMZ> UzytkownicyMZs
		{
			get
			{
				return this.GetTable<UzytkownicyMZ>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Gry")]
	public partial class GryMZ : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _id;
		
		private string _nazwa;
		
		private string _opis;
		
		private float _cena;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(short value);
    partial void OnidChanged();
    partial void OnnazwaChanging(string value);
    partial void OnnazwaChanged();
    partial void OnopisChanging(string value);
    partial void OnopisChanged();
    partial void OncenaChanging(float value);
    partial void OncenaChanged();
    #endregion
		
		public GryMZ()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nazwa", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string nazwa
		{
			get
			{
				return this._nazwa;
			}
			set
			{
				if ((this._nazwa != value))
				{
					this.OnnazwaChanging(value);
					this.SendPropertyChanging();
					this._nazwa = value;
					this.SendPropertyChanged("nazwa");
					this.OnnazwaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_opis", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string opis
		{
			get
			{
				return this._opis;
			}
			set
			{
				if ((this._opis != value))
				{
					this.OnopisChanging(value);
					this.SendPropertyChanging();
					this._opis = value;
					this.SendPropertyChanged("opis");
					this.OnopisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cena", DbType="Real NOT NULL")]
		public float cena
		{
			get
			{
				return this._cena;
			}
			set
			{
				if ((this._cena != value))
				{
					this.OncenaChanging(value);
					this.SendPropertyChanging();
					this._cena = value;
					this.SendPropertyChanged("cena");
					this.OncenaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Uzytkownicy")]
	public partial class UzytkownicyMZ : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _id;
		
		private string _login;
		
		private string _haslo;
		
		private string _mail;
		
		private string _imie;
		
		private string _nazwisko;
		
		private string _miasto;
		
		private string _k_pocztowy;
		
		private string _ulica;
		
		private string _nr_domu;
		
		private string _nr_bloku;
		
		private string _nr_mieszkania;
		
		private byte _typ_konta;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(short value);
    partial void OnidChanged();
    partial void OnloginChanging(string value);
    partial void OnloginChanged();
    partial void OnhasloChanging(string value);
    partial void OnhasloChanged();
    partial void OnmailChanging(string value);
    partial void OnmailChanged();
    partial void OnimieChanging(string value);
    partial void OnimieChanged();
    partial void OnnazwiskoChanging(string value);
    partial void OnnazwiskoChanged();
    partial void OnmiastoChanging(string value);
    partial void OnmiastoChanged();
    partial void Onk_pocztowyChanging(string value);
    partial void Onk_pocztowyChanged();
    partial void OnulicaChanging(string value);
    partial void OnulicaChanged();
    partial void Onnr_domuChanging(string value);
    partial void Onnr_domuChanged();
    partial void Onnr_blokuChanging(string value);
    partial void Onnr_blokuChanged();
    partial void Onnr_mieszkaniaChanging(string value);
    partial void Onnr_mieszkaniaChanged();
    partial void Ontyp_kontaChanging(byte value);
    partial void Ontyp_kontaChanged();
    #endregion
		
		public UzytkownicyMZ()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="SmallInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public short id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_login", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string login
		{
			get
			{
				return this._login;
			}
			set
			{
				if ((this._login != value))
				{
					this.OnloginChanging(value);
					this.SendPropertyChanging();
					this._login = value;
					this.SendPropertyChanged("login");
					this.OnloginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_haslo", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string haslo
		{
			get
			{
				return this._haslo;
			}
			set
			{
				if ((this._haslo != value))
				{
					this.OnhasloChanging(value);
					this.SendPropertyChanging();
					this._haslo = value;
					this.SendPropertyChanged("haslo");
					this.OnhasloChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mail", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string mail
		{
			get
			{
				return this._mail;
			}
			set
			{
				if ((this._mail != value))
				{
					this.OnmailChanging(value);
					this.SendPropertyChanging();
					this._mail = value;
					this.SendPropertyChanged("mail");
					this.OnmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_imie", DbType="NVarChar(MAX)")]
		public string imie
		{
			get
			{
				return this._imie;
			}
			set
			{
				if ((this._imie != value))
				{
					this.OnimieChanging(value);
					this.SendPropertyChanging();
					this._imie = value;
					this.SendPropertyChanged("imie");
					this.OnimieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nazwisko", DbType="NVarChar(MAX)")]
		public string nazwisko
		{
			get
			{
				return this._nazwisko;
			}
			set
			{
				if ((this._nazwisko != value))
				{
					this.OnnazwiskoChanging(value);
					this.SendPropertyChanging();
					this._nazwisko = value;
					this.SendPropertyChanged("nazwisko");
					this.OnnazwiskoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_miasto", DbType="NVarChar(MAX)")]
		public string miasto
		{
			get
			{
				return this._miasto;
			}
			set
			{
				if ((this._miasto != value))
				{
					this.OnmiastoChanging(value);
					this.SendPropertyChanging();
					this._miasto = value;
					this.SendPropertyChanged("miasto");
					this.OnmiastoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_k_pocztowy", DbType="NVarChar(MAX)")]
		public string k_pocztowy
		{
			get
			{
				return this._k_pocztowy;
			}
			set
			{
				if ((this._k_pocztowy != value))
				{
					this.Onk_pocztowyChanging(value);
					this.SendPropertyChanging();
					this._k_pocztowy = value;
					this.SendPropertyChanged("k_pocztowy");
					this.Onk_pocztowyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ulica", DbType="NVarChar(MAX)")]
		public string ulica
		{
			get
			{
				return this._ulica;
			}
			set
			{
				if ((this._ulica != value))
				{
					this.OnulicaChanging(value);
					this.SendPropertyChanging();
					this._ulica = value;
					this.SendPropertyChanged("ulica");
					this.OnulicaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nr_domu", DbType="NVarChar(MAX)")]
		public string nr_domu
		{
			get
			{
				return this._nr_domu;
			}
			set
			{
				if ((this._nr_domu != value))
				{
					this.Onnr_domuChanging(value);
					this.SendPropertyChanging();
					this._nr_domu = value;
					this.SendPropertyChanged("nr_domu");
					this.Onnr_domuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nr_bloku", DbType="NVarChar(MAX)")]
		public string nr_bloku
		{
			get
			{
				return this._nr_bloku;
			}
			set
			{
				if ((this._nr_bloku != value))
				{
					this.Onnr_blokuChanging(value);
					this.SendPropertyChanging();
					this._nr_bloku = value;
					this.SendPropertyChanged("nr_bloku");
					this.Onnr_blokuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nr_mieszkania", DbType="NVarChar(MAX)")]
		public string nr_mieszkania
		{
			get
			{
				return this._nr_mieszkania;
			}
			set
			{
				if ((this._nr_mieszkania != value))
				{
					this.Onnr_mieszkaniaChanging(value);
					this.SendPropertyChanging();
					this._nr_mieszkania = value;
					this.SendPropertyChanged("nr_mieszkania");
					this.Onnr_mieszkaniaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_typ_konta", DbType="TinyInt NOT NULL")]
		public byte typ_konta
		{
			get
			{
				return this._typ_konta;
			}
			set
			{
				if ((this._typ_konta != value))
				{
					this.Ontyp_kontaChanging(value);
					this.SendPropertyChanging();
					this._typ_konta = value;
					this.SendPropertyChanged("typ_konta");
					this.Ontyp_kontaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591