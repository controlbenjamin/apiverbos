   public IEnumerable<Models.Producto> Get()
        {
            IEnumerable<Models.Producto> lista;


            using (var db = new Models.DataClassesProductosDataContext())
            {
                var resultado = from tablaProductos in db.Productos
                                select tablaProductos;
                lista = resultado.ToList<Models.Producto>();
            }

            return lista;

        }

        public IHttpActionResult Post(Models.Producto parametro)
        {
            using (var db = new Models.DataClassesProductosDataContext())
            {
                db.Productos.InsertOnSubmit(parametro);
                db.SubmitChanges();
            }

            return Ok("Registro insertado!");
        }

        public Models.Producto Get(int id)
        {

            Models.Producto obj = new Models.Producto();

            using (var db = new Models.DataClassesProductosDataContext())
            {
                obj = db.Productos.Where(parametro => parametro.Id.Equals(id)).First();
            }

            return obj;
        }

        public void Delete(int id)
        {
            

            using (var db = new Models.DataClassesProductosDataContext())
            {

                // Query the database for the row to be updated.
                var query =
                    from prod in db.Productos
                    where prod.Id == id
                    select prod;

                // Execute the query, and change the column values
                // you want to change.

                foreach (Models.Producto prod in query)
                {
                    prod.Activo = false;
                    // Insert any additional changes to column values.
                }

                db.SubmitChanges();
            }

        }