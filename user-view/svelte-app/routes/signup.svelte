
<script lang="ts">
	import Button, { Label } from '@smui/button';
	import Textfield from '@smui/textfield';
   	import {API} from '../data/api';
	import type User from '../data/model';
	

	let api = new API();
	let response;
	let user: User = {id:0, userName: '', fullName:''};
	async function saveUser ()  {
		console.log("Posting user to backend");
		response = await api.userSignupPost('/user_info', user);
		console.debug('Response from userSignupPost/user_info', response);
		user = {id:0, userName: '', fullName:''};
	}
  </script>

<main style="display: flex; flex-direction: column;">
	<h1>Sign Up</h1>
	<div style="display: flex; align-items: self-end; margin: 0 auto;">
		<div style="margin-right: 10px;">
			<Textfield label="User Name" bind:value={user.userName}/>
			<Textfield label="Full Name" bind:value={user.fullName}/>
		</div>
		
		<div style="margin-right: 10px;">
			<Button variant="outlined" on:click={saveUser}>
				<Label>Sign Up</Label>
			</Button>
		</div>
		<div>{response && response.data}</div>
	</div>
	
</main>


<style>
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		font-size: 2em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>