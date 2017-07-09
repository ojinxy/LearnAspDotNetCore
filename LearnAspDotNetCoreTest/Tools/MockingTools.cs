using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace LearnAspDotNetCoreTest.Tools
{
    public class MockingTools
    {
        public MockingTools()
        {
        }

        /*
         * GetMockDbSet- Returns a Mocked DbSet based on the list of objects
         * passed into the function
         * @Arguments - sourceList (A comma seperated list of new objects)
        */
        public static DbSet<T> GetMockDbSet<T>(params T[] sourceList)
            where T : class
        {
            var queryable = sourceList.AsQueryable();

            return CreateMockDbSet(queryable);
        }

		/*
		* GetMockDbSet- Returns a Orginal Mocked DbSet based on the list of objects
		* passed into the function
		* @Arguments - sourceList (A comma seperated list of new objects)
	   */
		public static Mock<DbSet<T>> GetMockDbSetOrginal<T>(params T[] sourceList)
			where T : class
		{
			var queryable = sourceList.AsQueryable();

			return CeateMockDbSetOrginal(queryable);
		}

        /*
    	  * GetMockDbSet- Returns a Mocked DbSet based on the list of objects
    	  * passed into the function
    	  * @Arguments - sourceList (A List of objects)
    	 */
        public static DbSet<T> GetMockDbSet<T>(List<T> sourceList)
             where T : class
        {
            var queryable = sourceList.AsQueryable();

            return CreateMockDbSet(queryable);
        }

        private static DbSet<T> CreateMockDbSet<T>(IQueryable<T> queryable) where T : class
        {
			var dbSet = new Mock<DbSet<T>>();

			/*Mocking underling necessary IQuerable interface*/
			dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

			return dbSet.Object;
        }

		private static Mock<DbSet<T>> CeateMockDbSetOrginal<T>(IQueryable<T> queryable) where T : class
		{
			var dbSet = new Mock<DbSet<T>>();

			/*Mocking underling necessary IQuerable interface*/
			dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
			dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
			dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
			dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

			return dbSet;
		}


    }
}
