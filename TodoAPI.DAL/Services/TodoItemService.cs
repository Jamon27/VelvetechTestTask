﻿using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.DAL.Models;
using TodoApi.DAL.Context;
using TodoApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TodoApi.DAL.Repositories
{
    internal class TodoItemService : IRepository<TodoItem>
    {
        private TodoContext db;

        public TodoItemService(TodoContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await db.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemAsync(long id)
        {
            return await db.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TodoItem> CreateTodoItemAsync(TodoItem todoItem)
        {
            db.TodoItems.Add(todoItem);
            await db.SaveChangesAsync();

            return todoItem;
        }

        public async Task UpdateTodoItemAsync(TodoItem todoItem)
        {
            db.Entry(todoItem).State = EntityState.Modified;

            await db.SaveChangesAsync();
        }

        public async Task DeleteTodoItemAsync(long id)
        {
            TodoItem todoItem = await db.TodoItems.FindAsync(id);
            if (todoItem != null)
                db.TodoItems.Remove(todoItem);
            await db.SaveChangesAsync();
        }
    }
}
