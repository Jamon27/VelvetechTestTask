﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.BLL.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItemDTO> GetTodoItemAsync(long id);
        Task<IEnumerable<TodoItemDTO>> GetTodoItemsAsync();
        Task UpdateTodoItemAsync(long id, TodoItemDTO todoItemDTO);
        Task<TodoItemDTO> CreateTodoItemAsync(TodoItemDTO todoItemDTO);
        Task DeleteTodoItemAsync(long id);
        void Dispose();        
    }
}
