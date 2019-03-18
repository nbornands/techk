using System;
using System.Net;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace techk
{
    public partial class techk : System.Web.UI.Page
    {
        string alumnosJson = string.Empty;
        string eventosJson = string.Empty;
        string regionesJson = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //METODOS PARA CONSUMIR JSON
        protected void consumirJsonAlumnos() {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                alumnosJson = wc.DownloadString("https://pastebin.com/raw/EPAN0zZe");
            }
        }

        protected void consumirJsonEventos() {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                eventosJson = wc.DownloadString("https://pastebin.com/raw/qdN6Wp3i");
            }
        }

        protected void consumirJsonRegiones() {
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                regionesJson = wc.DownloadString("https://pastebin.com/raw/6TmBZjVn");
            }
        }


        //METODOS PARA POBLAR GRILLAS
        protected DataTable alumnoJsonToDataTable()
        {
            consumirJsonAlumnos();

            DataTable dtAlumnos = new DataTable();
            dtAlumnos.Columns.Add("name", typeof(string));
            dtAlumnos.Columns.Add("grades", typeof(string));
            dtAlumnos.Columns.Add("birth", typeof(string));
            dtAlumnos.Columns.Add("avrg", typeof(double));

            try
            {
                JArray ja = JArray.Parse(alumnosJson);
                for (int i = 0; i < ja.Count; i++)
                {
                    DataRow dr = dtAlumnos.NewRow();
                    dr["name"] = ja[i]["name"].ToString();
                    dr["grades"] = ja[i]["grades"].ToString().Trim(new char[] { '[', ']' }).Replace(",", " |");
                    dr["birth"] = ja[i]["birth"].ToString();
                    string[] notas = ja[i]["grades"].ToString().Trim(new char[] { '[', ']' }).Split(',');
                    dr["avrg"] = calcularPromedio(notas);
                    dtAlumnos.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtAlumnos;
        }

        protected double calcularPromedio(string[] notas) {
            double suma = 0;
            double promedio = 0;
            try {
                for (int i = 0; i < notas.Length; i++) {
                    suma += Convert.ToDouble(notas[i].Replace(".",","));
                }
                promedio = suma / notas.Length;
                promedio = Math.Round(promedio,1);
            }
            catch(Exception ex){
                ex.ToString();
            }
            return promedio;
        }

        protected void cargarAlumnos()
        {
            gvAlumnos.DataSource = alumnoJsonToDataTable();
            gvAlumnos.DataBind();
        }

        protected void cargarEventos()
        {
            consumirJsonEventos();
            gvEventos.DataSource = (DataTable)JsonConvert.DeserializeObject(eventosJson, typeof(DataTable)); ;
            gvEventos.DataBind();
        }

        protected void cargarRegiones()
        {
            consumirJsonRegiones();
            gvRegiones.DataSource = (DataTable)JsonConvert.DeserializeObject(regionesJson, typeof(DataTable)); ;
            gvRegiones.DataBind();
        }


        //METODOS PARA ORDENAR GRILLAS
        protected void sortAlumnosAvrg() {

            DataView dv = new DataView(alumnoJsonToDataTable());
            DataTable dtAlumnos = new DataTable();

            if (btnOrdenarNotas.Text == "Ordenar Promedio - Asc")
            {
                dv.Sort = "avrg asc";
                dtAlumnos = dv.ToTable();
                btnOrdenarNotas.Text = "Ordenar Promedio - Desc";
            }
            else {
                dv.Sort = "avrg desc";
                dtAlumnos = dv.ToTable();
                btnOrdenarNotas.Text = "Ordenar Promedio - Asc";
            }

            gvAlumnos.DataSource = dtAlumnos;
            gvAlumnos.DataBind();
        }

        protected void sortAlumnosEdad() {
            DataView dv = new DataView(alumnoJsonToDataTable());
            DataTable dtAlumnos = new DataTable();

            if (btnOrdenarAlumnos.Text == "Por Edad - Asc")
            {
                dv.Sort = "birth desc";
                dtAlumnos = dv.ToTable();
                btnOrdenarAlumnos.Text = "Por Edad - Desc";
            }
            else
            {
                dv.Sort = "birth asc";
                dtAlumnos = dv.ToTable();
                btnOrdenarAlumnos.Text = "Por Edad - Desc";
            }

            gvAlumnos.DataSource = dtAlumnos;
            gvAlumnos.DataBind();
        }

        protected void sortEventosTime() {
            consumirJsonEventos();
            DataView dv = new DataView((DataTable)JsonConvert.DeserializeObject(eventosJson, typeof(DataTable)));
            DataTable dtEventos = new DataTable();

            if (btnOrdenarFecha.Text == "Por Fech - Asc")
            {
                dv.Sort = "time desc";
                dtEventos = dv.ToTable();
                btnOrdenarFecha.Text = "Por Fech - Desc";
            }
            else {

                dv.Sort = "time asc";
                dtEventos = dv.ToTable();
                btnOrdenarFecha.Text = "Por Fech - Asc";
            }

            gvEventos.DataSource = dtEventos;
            gvEventos.DataBind();

        }

        protected void sortRegionNumber() {
            consumirJsonRegiones();
            DataView dv = new DataView((DataTable)JsonConvert.DeserializeObject(regionesJson, typeof(DataTable)));
            DataTable dtRegiones = new DataTable();

            if (btnOrdenarRegion.Text == "Por Número - Asc")
            {
                dv.Sort = "number asc";
                dtRegiones = dv.ToTable();
                btnOrdenarRegion.Text = "Por Número - Desc";
            }
            else {
                dv.Sort = "number desc";
                dtRegiones = dv.ToTable();
                btnOrdenarRegion.Text = "Por Número - Asc";
            }

            gvRegiones.DataSource = dtRegiones;
            gvRegiones.DataBind();
        }


        //EVETOS DE BOTONES
        protected void btInicio_Click(object sender, EventArgs e)
        {
            inicio.Visible = true;
            alumnos.Visible = false;
            eventos.Visible = false;
            regiones.Visible = false;
        }

        protected void btAlumnos_Click(object sender, EventArgs e)
        {

            cargarAlumnos();
            alumnos.Visible = true;
            inicio.Visible = false;
            eventos.Visible = false;
            regiones.Visible = false;
        }

        protected void btEventos_Click(object sender, EventArgs e)
        {
            cargarEventos();
            eventos.Visible = true;
            alumnos.Visible = false;
            inicio.Visible = false;
            regiones.Visible = false;
        }

        protected void btRegiones_Click(object sender, EventArgs e)
        {
            cargarRegiones();
            regiones.Visible = true;
            eventos.Visible = false;
            alumnos.Visible = false;
            inicio.Visible = false;
            
        }

        protected void btnOrdenarAlumnosAvrg_Click(object sender, EventArgs e)
        {
            sortAlumnosAvrg();
        }

        protected void btnOrdenarAlumnosBirth_Click(object sender, EventArgs e)
        {
            sortAlumnosEdad();
        }

        protected void btnOrdenarFecha_Click(object sender, EventArgs e)
        {
            sortEventosTime();
        }

        protected void btnOrdenarRegion_Click(object sender, EventArgs e)
        {
            sortRegionNumber();
        }
    }
}