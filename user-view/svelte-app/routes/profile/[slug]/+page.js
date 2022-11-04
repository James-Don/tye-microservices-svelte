// import { error } from '@sveltejs/kit';
 
/** @type {import('./$types').PageLoad} */
export function load({ params }) {
  console.debug('profile/[slug]/*page.js: ', params.slug);
  //TODO fetch user by ID
    return {
      fullName: 'some fullname',
      userName: 'some username'
    };
 
  // throw error(404, 'Not found');
}