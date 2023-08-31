using Microsoft.AspNetCore.Mvc;
using UserManagementSystem.Models;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private static Dictionary<string, User> users = new Dictionary<string, User>();  // For demo, we use in-memory storage.

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll()
    {
        if (users.Count == 0)
        {
            return NotFound("No users found.");
        }

        return Ok(users.Values);
    }

    // GET api/users/{username}
    [HttpGet("{username}")]
    public ActionResult<User> GetByUsername(string username)
    {
        if (!users.TryGetValue(username, out var user))
        {
            return NotFound("User not found.");
        }

        return user;
    }

    // POST api/users
    [HttpPost]
    public ActionResult<string> Create(User user)
    {
        if (users.ContainsKey(user.Username))
            return Conflict("Username already exists.");

        users[user.Username] = user;
        return $"User {user.Username} created successfully.";
    }

    // PUT api/users/{username}
    [HttpPut("{username}")]
    public IActionResult Update(string username, User user)
    {
        if (!users.ContainsKey(username))
            return NotFound();

        user.Username = username;  // Ensure the username remains consistent.
        users[username] = user;

        return NoContent();
    }

    // DELETE api/users/{username}
    [HttpDelete("{username}")]
    public IActionResult Delete(string username)
    {
        if (!users.ContainsKey(username))
            return NotFound();

        users.Remove(username);
        return NoContent();
    }
}
