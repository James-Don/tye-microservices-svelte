<script lang="ts">
	import { Router, Route, Link } from "svelte-navigator";
	import Search from "./routes/search.svelte";
	import Signup from "./routes/signup.svelte";
	import Profile from "./routes/profile/[slug]/+page.svelte";

  </script>
  
  <Router>
	<header>
	  <h1>User Service</h1>
  
	  <nav>
		<Link to="/">Home</Link>
		<br>
		<Link to="signup">Signup</Link>
		<br>
		<Link to="search">Search</Link>
		<br>
		<Link to="profile/123">Profile</Link>
	  </nav>
	</header>
  
	<main>
		<Route path="/">
			<h3>UserServices Home</h3>
			<p>User service of sign-up and search.</p>
		</Route>

	  <Route path="signup">
		<h3>Sign up</h3>
		<Signup />
		<p>Sign up user</p>
	  </Route>
  
	  <Route path="search">
		<h3>Search</h3>
		<Search />
		<p>Search user.</p>
	  </Route>

	  <Route path="profile/:slug" >
		<h3>Profile</h3>
		<Profile data/>
		<p>User profile</p>
	  </Route>
  
	
	</main>
  </Router>
  