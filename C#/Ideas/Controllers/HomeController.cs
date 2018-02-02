using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using dojoTest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace dojoTest.Controllers
{

    public class HomeController : Controller
    {
        private DojoContext _context;
        public HomeController(DojoContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Dashboard()
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("LoginPage", "User");                           
            }
            else
            {   
                List<User> Users = _context.Users.Include(p=>p.Posts).ThenInclude(l=>l.Likes).ToList();
                List<Post> Posts = _context.Posts.Include(u=>u.Likes).OrderByDescending(x => x.Created_At).ToList();
                User selectedUser = _context.Users.Where(u=>u.UserId == id).Include(p=>p.Posts).ThenInclude(l=>l.Likes).SingleOrDefault();
                // Like exists = _context.Likes.Where(p=>p.PostId == Posts.).Where(u=>u.UserId == id).FirstOrDefault();



                ViewBag.LoggedinUser = id;
                ViewBag.AllPosts = Posts;
                ViewBag.User = selectedUser;
                ViewBag.UserName = HttpContext.Session.GetString("name");
                return View("Dashboard");
            }
        }

        [HttpPost]
        [Route("/newpost")]
        public IActionResult CreatePost(UserPost check)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {   
                if(ModelState.IsValid)
                {
                    Post newPost = new Post
                    {
                        Content = check.Content,
                        Created_At = DateTime.Now,
                        UserId = (int)id,
                    };
                    _context.Posts.Add(newPost);
                    _context.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    TempData["PostError"] = "Post must be at least 5 characters";
                    return RedirectToAction("Dashboard");
                }
            }
        }

        [HttpGet]
        [Route("/user/{userId}")]
        public IActionResult UserPage(int userId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("LoginPage", "User");                           
            }
            else
            {
                User selectedUser = _context.Users.Where(u=>u.UserId == userId).Include(p=>p.Posts).ThenInclude(l=>l.Likes).SingleOrDefault();
                List<Like> userLikes = _context.Likes.Where(u=>u.UserId == userId).ToList();
                
                ViewBag.Likes = userLikes;
                ViewBag.User = selectedUser;
                return View("UserPage");
            }
        }

        [HttpGet]
        [Route("/like/{postId}")]
        public IActionResult Like(int postId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("RegisterPage", "User");                           
            }
            else
            {
                Like exists = _context.Likes.Where(p=>p.PostId == postId).Where(u=>u.UserId == id).FirstOrDefault();
                if(exists == null)
                {
                    Like newLike = new Like
                    {
                        PostId = postId,
                        UserId = (int)id,
                    };
                    _context.Likes.Add(newLike);
                    _context.SaveChanges();
                    
                    // bool heart = true;
                    
                    // ViewBag.heart = heart;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    _context.Likes.Remove(exists);
                    _context.SaveChanges();
                    // bool heart = false;
                    // ViewBag.heart = heart;                
                    return RedirectToAction("Dashboard");
                }
            }
        }

        [HttpGet]
        [Route("/post/{postId}")]
        public IActionResult PostPage(int postId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("LoginPage", "User");                           
            }
            else
            {
                Post selectedPost = _context.Posts.Where(u=>u.PostId == postId).Include(l=>l.Likes).SingleOrDefault();
                Like likes = _context.Likes.Where(p=>p.PostId == postId).FirstOrDefault();
                User selectedUser = _context.Users.Where(u=>u.UserId == selectedPost.UserId).FirstOrDefault();
                List<Like> likesList = _context.Likes.Where(p=>p.PostId == postId).Include(u=>u.LikedBy).ToList();
                // List<User> userswholiked = _context.Users.Include(users=>users.)

                // User users = _context.Users.Include(user=>user.Likes).Where(l=>l.PostId == selectedUser.UserId).FirstOrDefault();

                
                ViewBag.Post = selectedPost;
                ViewBag.LikesList = likesList;
                ViewBag.name = selectedUser.FirstName;
                // ViewBag.users = users;
                return View("PostPage");
            }
        }

        [HttpGet]
        [Route("/delete/{postId}")]
        public IActionResult PostDelete(int postId)
        {
            int? id = HttpContext.Session.GetInt32("userId");
            if(id == null)
            {
                return RedirectToAction("LoginPage", "User");                           
            }
            else
            {
                Post selectedPost = _context.Posts.Where(u=>u.PostId == postId).Include(l=>l.Likes).SingleOrDefault();
                _context.Posts.Remove(selectedPost);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
        }

    }
}
