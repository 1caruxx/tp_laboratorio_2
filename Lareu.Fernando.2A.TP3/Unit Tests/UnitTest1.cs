using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace Unit_Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Valida que el DNI de un extranjero sea maayor a 89999999
        /// </summary>
        [TestMethod]
        public void ValidarNacionalidadInvalidaException()
        {
            Alumno alumno;

            try
            {
                alumno = new Alumno(1, "Fernando", "Lareu", "40793784", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception excepcion)
            {
                Assert.IsInstanceOfType(excepcion, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Valida que haya un profesor para la clase correspondiente.
        /// </summary>
        [TestMethod]
        public void ValidarSinProfesorException()
        {
            Universidad universidad = new Universidad();

            try
            {
                universidad += Universidad.EClases.Laboratorio;
            }
            catch (Exception excepcion)
            {
                Assert.IsInstanceOfType(excepcion, typeof(SinProfesorException));
            }
        }

        /// <summary>
        /// Valida que no se carguen dos alumnos con el mismo legajo o DNI.
        /// </summary>
        [TestMethod]
        public void ValidarAlumnoRepetidoException()
        {
            Universidad universidad = new Universidad();
            Alumno alumno = new Alumno(1, "Fernando", "Lareu", "40793784", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(1, "Fernando", "Lareu", "40793784", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            universidad += alumno2;

            try
            {
                universidad += alumno2;
            }
            catch (Exception excepcion)
            {
                Assert.IsInstanceOfType(excepcion, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Valida que la cantidad de alumnos cargados sea correcta.
        /// </summary>
        [TestMethod]
        public void ValidarCantidadDeAlumnos()
        {
            Alumno alumno = new Alumno(1, "Fernando", "Lareu", "40793784", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno alumno2 = new Alumno(2, "Juan", "Lopez", "12234456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Becado);
            Alumno alumno3 = new Alumno(4, "Miguel", "Hernandez", "92264456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno4 = new Alumno(5, "Carlos", "Gonzalez", "12236456", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.AlDia);
            Universidad universidad = new Universidad();

            universidad += alumno;
            universidad += alumno2;
            universidad += alumno3;
            universidad += alumno4;

            Assert.AreEqual(universidad.Alumnos.Count, 4);
        }

        /// <summary>
        /// Validad que ninguno de los atributos de la instancia sean nulos.
        /// </summary>
        [TestMethod]
        public void ValidarAtributosNulos()
        {
            Alumno alumno = new Alumno(1, "Fernando", "Lareu", "40793784", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsNotNull(alumno.DNI);
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.Nombre);
            Assert.IsNotNull(alumno.Nacionalidad);
        }
    }
}
