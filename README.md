# Learn github

This repository is designed as a learning environment to explore and experiment with the features of the GitHub platform, especially GitHub Actions, to build Continuous Integration and Continuous Deployment (CI/CD) pipelines.


## Workflows

We'll explore how GitHub Actions can automate the build and release processes by creating and experimenting with two workflows:

- ✅ Build Workflow: Triggered on: Pull requests to the main branch, Pushes to the main branch, or Manual dispatch.
- 🚀 Release Workflow: Triggered on: Pushes to the release branch.

These workflows are defined in the `.github/workflows/` directory. Through these examples, we’ll observe how workflows behave in different scenarios:

- [x] Which versions of the workflows are triggered on different events.
- [x] Types of events that trigger workflows
- [x] Conditional execution of the workflows based on the event type.
- [x] How to access secrets and environment variables securely.
- [x] Usage of reusable actions and reusable workflows for better modularity and maintainability.

## Caching 

Explore the caching features of GitHub Actions to speed up the build process. we will create a cache for the build artifacts and dependencies.
