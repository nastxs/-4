using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Интерфейсы;
using Npgsql;
using лаба4;
using System.Reflection.Emit;
using Лабораторная_работа__4;
using Microsoft.EntityFrameworkCore;

namespace Лабa4.Классы
{
    public class TriangleProvider : ITriangleProvider
    {
        public List<Triangle> GetAll()
          {
              using (TrianglesContext db = new TrianglesContext())
              {
                  var triangles = db.triangle.ToList();
                  return triangles;
              }
          }

          public Triangle GetById(int id)
          {
              using (TrianglesContext db = new TrianglesContext())
              {
                  var result = db.triangle.FromSqlRaw($"SELECT * FROM triangle_table WHERE id = {id}").ToList();
                  return result[0];
              }
          }

          public void Save(Triangle triangle)
          {
              using (TrianglesContext db = new TrianglesContext())
              {
                  db.triangle.AddRange(triangle);
                  db.SaveChanges();
              }
          }






        /*private readonly string path;
        public TriangleProvider(string path)
        {
            this.path = path;
        }
        public Triangle GetById(int id)
        {
            Triangle triangle = new Triangle();
            using (var con = new NpgsqlConnection(path))
            {

                con.Open();
                string sql = $"SELECT * FROM Triangles WHERE id = {id}";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    triangle.id = reader.GetInt32(reader.GetOrdinal("id"));
                    triangle.a = reader.GetDouble(reader.GetOrdinal("a"));
                    triangle.b = reader.GetDouble(reader.GetOrdinal("b"));
                    triangle.c = reader.GetDouble(reader.GetOrdinal("c"));
                    triangle.sq = reader.GetDouble(reader.GetOrdinal("square"));
                    triangle.type = reader.GetString(reader.GetOrdinal("type"));
                }
            }
            return triangle;
        }


        public List<Triangle> GetAll()
        {
            List<Triangle> triangle = new List<Triangle>();
            using (var con = new NpgsqlConnection(path))
            {
                con.Open();
                string sql = $"SELECT * FROM Triangles";
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    triangle.Add(new Triangle(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader.GetDouble(reader.GetOrdinal("a")),
                    reader.GetDouble(reader.GetOrdinal("b")),
                    reader.GetDouble(reader.GetOrdinal("c")),
                    reader.GetDouble(reader.GetOrdinal("square")),
                    reader.GetString(reader.GetOrdinal("type"))
                    ));
                }
            }
            return triangle;
        }
        public void Save(Triangle triangle)
        {
            var t = GetById(triangle.id);
            if (t.id != triangle.id)
            {

                using (var con = new NpgsqlConnection(path))
                {
                    con.Open();
                    string cmdText = $"INSERT INTO triangles VALUES ({triangle.id}, {triangle.a}, {triangle.b}, {triangle.c}, {triangle.sq}, '{triangle.type}')"; , { triangle.type}
                    NpgsqlCommand cmd = new NpgsqlCommand(cmdText, con);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
            /*else
            {
                using (var con = new NpgsqlConnection(path))
                {
                    con.Open();
                    string cmdText = $"Update Triangles set(a, b, c, square, type)= ( {triangle.a}, {triangle.b}, {triangle.c}, {triangle.sq}, '{triangle.type}') where id ={triangle.id}"; , { triangle.type}
                    NpgsqlCommand cmd = new NpgsqlCommand(cmdText, con);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }*/
        }

    }

